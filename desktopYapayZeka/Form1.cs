using System.Text;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Data;
using ExcelDataReader;
using System.Data.SqlClient;

namespace desktopYapayZeka
{
    public partial class Form1 : Form
    {
        private readonly HttpClient _httpClient;
        private readonly string _connectionString = "Server=BSTNB290;Database=hrYapay;Trusted_Connection=True;";

        public Form1()
        {
            InitializeComponent();
            _httpClient = new HttpClient();
        }

        private async Task<string> GeminiistekGonder(DonusumDTO data)
        {
            var requestBody = new
            {
                contents = new[]
                {
            new
            {
                parts = new[]
                {
                    new {
                        text = $"Çalýþan: {data.Ad} {data.Soyad}\n" +
                               $"Teknik Yeterlilik: {data.TeknikYeterlilik}, " +
                               $"Ýletiþim: {data.Iletisim}, " +
                               $"Performans: {data.Performans}\n" +
                               "Bu çalýþanýn deðerlendirmesini yap ve önerilerde bulun."
                    }
                }
            }
        }
            };
            var json = JsonConvert.SerializeObject(requestBody);
            var httpContent = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync("https://generativelanguage.googleapis.com/v1beta/models/gemini-1.5-flash-latest:generateContent?key=AIzaSyBAHjtJlK6bwvw__8dQtS8OEdAvy56hHt8", httpContent);
            if (response.IsSuccessStatusCode)
            {
                var responseContent = await response.Content.ReadAsStringAsync();
                Console.WriteLine(responseContent);

                try
                {
                    var result = JObject.Parse(responseContent);
                    var responseOutputu = result["candidates"]?[0]?["content"]?["parts"]?[0]?["text"]?.ToString();

                    return responseOutputu ?? "Yapay zeka dönüþ yapamadý.";
                }
                catch (JsonException ex)
                {
                    Console.WriteLine("JSON eror: " + ex.Message);
                    return "Yanýt alýnamadý.";
                }
            }

            return "API yanýt vermedi veya bir hata oluþtu.";
        }
        private async Task YavasYaz(string metin)
        {
            var kelimeler = metin.Split(' ');
            foreach (var kelime in kelimeler)
            {
                txtResult.AppendText(kelime + " ");
                await Task.Delay(100);
            }
            txtResult.AppendText(Environment.NewLine);
        }
        private async void BtnUpload_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Excel Dosyalarý|*.xlsx;*.xls";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        btnUpload.Enabled = false;
                        progressBar.Visible = true;
                        txtResult.Clear();

                        var dataListesi = ExcelOkutma(ofd.FileName);
                        foreach (var data in dataListesi)
                        {
                            var assessment = await GeminiistekGonder(data);
                            await YavasYaz(assessment);
                            KaydetVeritabanina(data, assessment);
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.Write("hata keke");
                    }
                    finally
                    {
                        btnUpload.Enabled = true;
                        progressBar.Visible = false;
                        txtResult.AppendText("Yapay zeka deðerlendirmesi tamamlandý." + Environment.NewLine);
                        Console.Write("sýradakini girebilirsin excele bas");
                    }
                }
            }
        }

        private void KaydetVeritabanina(DonusumDTO data, string assessment)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = "INSERT INTO EvaluationResults (Ad, Soyad, TeknikYeterlilik, Iletisim, Performans, Ortalama, Oneriler) " +
                               "VALUES (@Ad, @Soyad, @TeknikYeterlilik, @Iletisim, @Performans, @Ortalama, @Oneriler)";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Ad", data.Ad);
                    command.Parameters.AddWithValue("@Soyad", data.Soyad);
                    command.Parameters.AddWithValue("@TeknikYeterlilik", data.TeknikYeterlilik);
                    command.Parameters.AddWithValue("@Iletisim", data.Iletisim);
                    command.Parameters.AddWithValue("@Performans", data.Performans);
                    command.Parameters.AddWithValue("@Ortalama", (data.TeknikYeterlilik + data.Iletisim + data.Performans) / 3);
                    command.Parameters.AddWithValue("@Oneriler", assessment);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

        private List<DonusumDTO> ExcelOkutma(string dosyaYolu)
        {
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);

            var dataListesi = new List<DonusumDTO>();

            using (var stream = File.Open(dosyaYolu, FileMode.Open, FileAccess.Read))
            {
                using (var reader = ExcelReaderFactory.CreateReader(stream))
                {
                    var dataSet = reader.AsDataSet(new ExcelDataSetConfiguration()
                    {
                        ConfigureDataTable = (_) => new ExcelDataTableConfiguration()
                        {
                            UseHeaderRow = true
                        }
                    });
                    
                    var worksheet = dataSet.Tables[0];
                    
                    foreach (DataRow row in worksheet.Rows)
                    {
                        var data = new DonusumDTO
                        {
                            Ad = row["Ad"].ToString(),
                            Soyad = row["Soyad"].ToString(),
                            TeknikYeterlilik = Convert.ToInt32(row["Teknik Yeterlilik"]), 
                            Iletisim = Convert.ToInt32(row["Ýletiþim"]),
                            Performans = Convert.ToInt32(row["Performans"])
                        };
                        dataListesi.Add(data);
                    }
                }
            }            
            return dataListesi;
        }
    }
}
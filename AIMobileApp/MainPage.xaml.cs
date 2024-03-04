//Connect to local web services from Android emulators and iOS simulators(https://learn.microsoft.com/en-us/dotnet/maui/data-cloud/local-web-services?view=net-maui-8.0)
using Microsoft.Maui.Controls;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;

namespace AIMobileApp
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void OnLoanClicked(object sender, EventArgs e)
        {
            string BaseAddress = DeviceInfo.Platform == DevicePlatform.Android 
                    ? "https://10.0.2.2:53963" : "https://localhost:53963";
#if DEBUG
            HttpsClientHandlerService handler = new HttpsClientHandlerService();
            HttpClient Client = new HttpClient(handler.GetPlatformMessageHandler());
#else
            HttpClient Client = new HttpClient();
#endif
            object data = new
            {
                Checking_status = entChecking_status.Text,
                Duration = entDuration.Text,
                Credit_history = entCredit_history.Text,
                Purpose = entPurpose.Text,
                Credit_amount = entCredit_amount.Text,
                Savings_status = entSavings_status.Text,
                Employment = entEmployment.Text,
                Installment_commitment= entInstallment_commitment.Text,
                Personal_status = entPersonal_status.Text,
                Other_parties = entOther_parties.Text,
                Residence_since = entResidence_since.Text,
                Property_magnitude = entProperty_magnitude.Text,
                Age = entAge.Text,
                Other_payment_plans = entOther_payment_plans.Text,
                Housing = entHousing.Text,
                Existing_credits = entExisting_credits.Text,
                Job = entJob.Text,
                Num_dependents = entNum_dependents.Text,
                Own_telephone = entOwn_telephone.Text,
                Foreign_worker = cbForeign_worker.IsChecked,
            };
            string Uri = $"{BaseAddress}/predict";
            string strContent = JsonSerializer.Serialize(data);
            var content = new StringContent(strContent, Encoding.UTF8, "application/json");
            HttpResponseMessage Response = await Client.PostAsync(Uri, content);
            Response.EnsureSuccessStatusCode();
            string Json = await Response.Content.ReadAsStringAsync();
            var Result = JsonSerializer.Deserialize<ModelOutput>(Json);
            string predictedLabel = Result.PredictedLabel;
            float score = Result.Score.Max();
            await DisplayAlert("信用等級", $"{predictedLabel}, 信心指數:${score * 100:n2}%", "關閉");
        }
    }
}

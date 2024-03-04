using Microsoft.ML.Data;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace AIMobileApp
{
    public class ModelOutput
    {
        [JsonPropertyName(@"checking_status")]
        public float[] Checking_status { get; set; }

        [JsonPropertyName(@"duration")]
        public float Duration { get; set; }

        [JsonPropertyName(@"credit_history")]
        public float[] Credit_history { get; set; }

        [JsonPropertyName(@"purpose")]
        public float[] Purpose { get; set; }

        [JsonPropertyName(@"credit_amount")]
        public float Credit_amount { get; set; }

        [JsonPropertyName(@"savings_status")]
        public float[] Savings_status { get; set; }

        [JsonPropertyName(@"employment")]
        public float[] Employment { get; set; }

        [JsonPropertyName(@"installment_commitment")]
        public float Installment_commitment { get; set; }

        [JsonPropertyName(@"personal_status")]
        public float[] Personal_status { get; set; }

        [JsonPropertyName(@"other_parties")]
        public float[] Other_parties { get; set; }

        [JsonPropertyName(@"residence_since")]
        public float Residence_since { get; set; }

        [JsonPropertyName(@"property_magnitude")]
        public float[] Property_magnitude { get; set; }

        [JsonPropertyName(@"age")]
        public float Age { get; set; }

        [JsonPropertyName(@"other_payment_plans")]
        public float[] Other_payment_plans { get; set; }

        [JsonPropertyName(@"housing")]
        public float[] Housing { get; set; }

        [JsonPropertyName(@"existing_credits")]
        public float Existing_credits { get; set; }

        [JsonPropertyName(@"job")]
        public float[] Job { get; set; }

        [JsonPropertyName(@"num_dependents")]
        public float Num_dependents { get; set; }

        [JsonPropertyName(@"own_telephone")]
        public float[] Own_telephone { get; set; }

        [JsonPropertyName(@"foreign_worker")]
        public float Foreign_worker { get; set; }

        [JsonPropertyName(@"class")]
        public uint Class { get; set; }

        [JsonPropertyName(@"features")]
        public float[] Features { get; set; }

        [JsonPropertyName(@"predictedLabel")]
        public string PredictedLabel { get; set; }

        [JsonPropertyName(@"score")]
        public float[] Score { get; set; }

    }
}

﻿// This file was auto-generated by ML.NET Model Builder.
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.ML.Data;
using Microsoft.ML.Trainers.FastTree;
using Microsoft.ML.Trainers;
using Microsoft.ML;

namespace MLModel_ConsoleApp
{
    public partial class MLModel
    {
        public const string RetrainFilePath =  @"E:\Document\Microsoft\文章\AI時代的網站與手機App建置與開發\AI時代的網站與手機App建置與開發Part4 - 整合ML.NET與ASP.NET Core MVC網站 - 建立訓練機器學習模型\credit_customers.csv";
        public const char RetrainSeparatorChar = ',';
        public const bool RetrainHasHeader =  true;

         /// <summary>
        /// Train a new model with the provided dataset.
        /// </summary>
        /// <param name="outputModelPath">File path for saving the model. Should be similar to "C:\YourPath\ModelName.mlnet"</param>
        /// <param name="inputDataFilePath">Path to the data file for training.</param>
        /// <param name="separatorChar">Separator character for delimited training file.</param>
        /// <param name="hasHeader">Boolean if training file has a header.</param>
        public static void Train(string outputModelPath, string inputDataFilePath = RetrainFilePath, char separatorChar = RetrainSeparatorChar, bool hasHeader = RetrainHasHeader)
        {
            var mlContext = new MLContext();

            var data = LoadIDataViewFromFile(mlContext, inputDataFilePath, separatorChar, hasHeader);
            var model = RetrainModel(mlContext, data);
            SaveModel(mlContext, model, data, outputModelPath);
        }

        /// <summary>
        /// Load an IDataView from a file path.
        /// </summary>
        /// <param name="mlContext">The common context for all ML.NET operations.</param>
        /// <param name="inputDataFilePath">Path to the data file for training.</param>
        /// <param name="separatorChar">Separator character for delimited training file.</param>
        /// <param name="hasHeader">Boolean if training file has a header.</param>
        /// <returns>IDataView with loaded training data.</returns>
        public static IDataView LoadIDataViewFromFile(MLContext mlContext, string inputDataFilePath, char separatorChar, bool hasHeader)
        {
            return mlContext.Data.LoadFromTextFile<ModelInput>(inputDataFilePath, separatorChar, hasHeader);
        }



        /// <summary>
        /// Save a model at the specified path.
        /// </summary>
        /// <param name="mlContext">The common context for all ML.NET operations.</param>
        /// <param name="model">Model to save.</param>
        /// <param name="data">IDataView used to train the model.</param>
        /// <param name="modelSavePath">File path for saving the model. Should be similar to "C:\YourPath\ModelName.mlnet.</param>
        public static void SaveModel(MLContext mlContext, ITransformer model, IDataView data, string modelSavePath)
        {
            // Pull the data schema from the IDataView used for training the model
            DataViewSchema dataViewSchema = data.Schema;

            using (var fs = File.Create(modelSavePath))
            {
                mlContext.Model.Save(model, dataViewSchema, fs);
            }
        }


        /// <summary>
        /// Retrains model using the pipeline generated as part of the training process.
        /// </summary>
        /// <param name="mlContext"></param>
        /// <param name="trainData"></param>
        /// <returns></returns>
        public static ITransformer RetrainModel(MLContext mlContext, IDataView trainData)
        {
            var pipeline = BuildPipeline(mlContext);
            var model = pipeline.Fit(trainData);

            return model;
        }


        /// <summary>
        /// build the pipeline that is used from model builder. Use this function to retrain model.
        /// </summary>
        /// <param name="mlContext"></param>
        /// <returns></returns>
        public static IEstimator<ITransformer> BuildPipeline(MLContext mlContext)
        {
            // Data process configuration with pipeline data transformations
            var pipeline = mlContext.Transforms.ReplaceMissingValues(new []{new InputOutputColumnPair(@"duration", @"duration"),new InputOutputColumnPair(@"credit_amount", @"credit_amount"),new InputOutputColumnPair(@"installment_commitment", @"installment_commitment"),new InputOutputColumnPair(@"residence_since", @"residence_since"),new InputOutputColumnPair(@"age", @"age"),new InputOutputColumnPair(@"existing_credits", @"existing_credits"),new InputOutputColumnPair(@"num_dependents", @"num_dependents")})      
                                    .Append(mlContext.Transforms.Conversion.ConvertType(@"foreign_worker", @"foreign_worker"))      
                                    .Append(mlContext.Transforms.Text.FeaturizeText(inputColumnName:@"checking_status",outputColumnName:@"checking_status"))      
                                    .Append(mlContext.Transforms.Text.FeaturizeText(inputColumnName:@"credit_history",outputColumnName:@"credit_history"))      
                                    .Append(mlContext.Transforms.Text.FeaturizeText(inputColumnName:@"purpose",outputColumnName:@"purpose"))      
                                    .Append(mlContext.Transforms.Text.FeaturizeText(inputColumnName:@"savings_status",outputColumnName:@"savings_status"))      
                                    .Append(mlContext.Transforms.Text.FeaturizeText(inputColumnName:@"employment",outputColumnName:@"employment"))      
                                    .Append(mlContext.Transforms.Text.FeaturizeText(inputColumnName:@"personal_status",outputColumnName:@"personal_status"))      
                                    .Append(mlContext.Transforms.Text.FeaturizeText(inputColumnName:@"other_parties",outputColumnName:@"other_parties"))      
                                    .Append(mlContext.Transforms.Text.FeaturizeText(inputColumnName:@"property_magnitude",outputColumnName:@"property_magnitude"))      
                                    .Append(mlContext.Transforms.Text.FeaturizeText(inputColumnName:@"other_payment_plans",outputColumnName:@"other_payment_plans"))      
                                    .Append(mlContext.Transforms.Text.FeaturizeText(inputColumnName:@"housing",outputColumnName:@"housing"))      
                                    .Append(mlContext.Transforms.Text.FeaturizeText(inputColumnName:@"job",outputColumnName:@"job"))      
                                    .Append(mlContext.Transforms.Text.FeaturizeText(inputColumnName:@"own_telephone",outputColumnName:@"own_telephone"))      
                                    .Append(mlContext.Transforms.Concatenate(@"Features", new []{@"duration",@"credit_amount",@"installment_commitment",@"residence_since",@"age",@"existing_credits",@"num_dependents",@"foreign_worker",@"checking_status",@"credit_history",@"purpose",@"savings_status",@"employment",@"personal_status",@"other_parties",@"property_magnitude",@"other_payment_plans",@"housing",@"job",@"own_telephone"}))      
                                    .Append(mlContext.Transforms.Conversion.MapValueToKey(outputColumnName:@"class",inputColumnName:@"class",addKeyValueAnnotationsAsText:false))      
                                    .Append(mlContext.MulticlassClassification.Trainers.OneVersusAll(binaryEstimator:mlContext.BinaryClassification.Trainers.FastTree(new FastTreeBinaryTrainer.Options(){NumberOfLeaves=4,MinimumExampleCountPerLeaf=20,NumberOfTrees=4,MaximumBinCountPerFeature=254,FeatureFraction=1,LearningRate=0.1,LabelColumnName=@"class",FeatureColumnName=@"Features"}),labelColumnName: @"class"))      
                                    .Append(mlContext.Transforms.Conversion.MapKeyToValue(outputColumnName:@"PredictedLabel",inputColumnName:@"PredictedLabel"));

            return pipeline;
        }
    }
 }

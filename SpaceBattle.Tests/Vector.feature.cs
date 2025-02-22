﻿// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by SpecFlow (https://www.specflow.org/).
//      SpecFlow Version:3.9.0.0
//      SpecFlow Generator Version:3.9.0.0
// 
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------
#region Designer generated code
#pragma warning disable
namespace SpaceBattle.Tests
{
    using TechTalk.SpecFlow;
    using System;
    using System.Linq;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "3.9.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    public partial class VectorActionFeature : object, Xunit.IClassFixture<VectorActionFeature.FixtureData>, System.IDisposable
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
        private static string[] featureTags = ((string[])(null));
        
        private Xunit.Abstractions.ITestOutputHelper _testOutputHelper;
        
#line 1 "Vector.feature"
#line hidden
        
        public VectorActionFeature(VectorActionFeature.FixtureData fixtureData, SpaceBattle_Tests_XUnitAssemblyFixture assemblyFixture, Xunit.Abstractions.ITestOutputHelper testOutputHelper)
        {
            this._testOutputHelper = testOutputHelper;
            this.TestInitialize();
        }
        
        public static void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("ru"), "", "VectorAction", null, ProgrammingLanguage.CSharp, featureTags);
            testRunner.OnFeatureStart(featureInfo);
        }
        
        public static void FeatureTearDown()
        {
            testRunner.OnFeatureEnd();
            testRunner = null;
        }
        
        public void TestInitialize()
        {
        }
        
        public void TestTearDown()
        {
            testRunner.OnScenarioEnd();
        }
        
        public void ScenarioInitialize(TechTalk.SpecFlow.ScenarioInfo scenarioInfo)
        {
            testRunner.OnScenarioInitialize(scenarioInfo);
            testRunner.ScenarioContext.ScenarioContainer.RegisterInstanceAs<Xunit.Abstractions.ITestOutputHelper>(_testOutputHelper);
        }
        
        public void ScenarioStart()
        {
            testRunner.OnScenarioStart();
        }
        
        public void ScenarioCleanup()
        {
            testRunner.CollectScenarioErrors();
        }
        
        void System.IDisposable.Dispose()
        {
            this.TestTearDown();
        }
        
        [Xunit.SkippableFactAttribute(DisplayName="Сравнение двух векторов верно")]
        [Xunit.TraitAttribute("FeatureTitle", "VectorAction")]
        [Xunit.TraitAttribute("Description", "Сравнение двух векторов верно")]
        public void СравнениеДвухВекторовВерно()
        {
            string[] tagsOfScenario = ((string[])(null));
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Сравнение двух векторов верно", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 5
this.ScenarioInitialize(scenarioInfo);
#line hidden
            if ((TagHelper.ContainsIgnoreTag(tagsOfScenario) || TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 6
 testRunner.Given("первый вектор равен (5, 3)", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Дано ");
#line hidden
#line 7
 testRunner.And("второй вектор равен (5, 3)", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "И ");
#line hidden
#line 8
 testRunner.When("происходит сравнение векторов", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Когда ");
#line hidden
#line 9
 testRunner.Then("получаем (true)", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Тогда ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [Xunit.SkippableFactAttribute(DisplayName="Сравнение двух векторов неверно ( разные значения )")]
        [Xunit.TraitAttribute("FeatureTitle", "VectorAction")]
        [Xunit.TraitAttribute("Description", "Сравнение двух векторов неверно ( разные значения )")]
        public void СравнениеДвухВекторовНеверноРазныеЗначения()
        {
            string[] tagsOfScenario = ((string[])(null));
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Сравнение двух векторов неверно ( разные значения )", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 11
this.ScenarioInitialize(scenarioInfo);
#line hidden
            if ((TagHelper.ContainsIgnoreTag(tagsOfScenario) || TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 12
 testRunner.Given("первый вектор равен (5, 3)", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Дано ");
#line hidden
#line 13
 testRunner.And("второй вектор равен (7, 3)", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "И ");
#line hidden
#line 14
 testRunner.When("происходит сравнение векторов", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Когда ");
#line hidden
#line 15
 testRunner.Then("получаем (false)", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Тогда ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [Xunit.SkippableFactAttribute(DisplayName="Сравнение двух векторов неверно")]
        [Xunit.TraitAttribute("FeatureTitle", "VectorAction")]
        [Xunit.TraitAttribute("Description", "Сравнение двух векторов неверно")]
        public void СравнениеДвухВекторовНеверно()
        {
            string[] tagsOfScenario = ((string[])(null));
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Сравнение двух векторов неверно", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 17
this.ScenarioInitialize(scenarioInfo);
#line hidden
            if ((TagHelper.ContainsIgnoreTag(tagsOfScenario) || TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 18
 testRunner.Given("первый вектор равен (5, 3)", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Дано ");
#line hidden
#line 19
 testRunner.And("второй вектор равен (7)", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "И ");
#line hidden
#line 20
 testRunner.When("происходит сравнение векторов", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Когда ");
#line hidden
#line 21
 testRunner.Then("получаем (false)", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Тогда ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [Xunit.SkippableFactAttribute(DisplayName="Сравнение двух векторов невозможно")]
        [Xunit.TraitAttribute("FeatureTitle", "VectorAction")]
        [Xunit.TraitAttribute("Description", "Сравнение двух векторов невозможно")]
        public void СравнениеДвухВекторовНевозможно()
        {
            string[] tagsOfScenario = ((string[])(null));
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Сравнение двух векторов невозможно", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 23
this.ScenarioInitialize(scenarioInfo);
#line hidden
            if ((TagHelper.ContainsIgnoreTag(tagsOfScenario) || TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 24
 testRunner.Given("первый вектор равен (5, 3)", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Дано ");
#line hidden
#line 25
 testRunner.And("второй вектор равен null", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "И ");
#line hidden
#line 26
 testRunner.When("происходит сравнение векторов", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Когда ");
#line hidden
#line 27
 testRunner.Then("возникает ошибка", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Тогда ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [Xunit.SkippableFactAttribute(DisplayName="Векторы с одинаковыми значениями имеют одинаковый хэш-код")]
        [Xunit.TraitAttribute("FeatureTitle", "VectorAction")]
        [Xunit.TraitAttribute("Description", "Векторы с одинаковыми значениями имеют одинаковый хэш-код")]
        public void ВекторыСОдинаковымиЗначениямиИмеютОдинаковыйХэш_Код()
        {
            string[] tagsOfScenario = ((string[])(null));
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Векторы с одинаковыми значениями имеют одинаковый хэш-код", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 29
this.ScenarioInitialize(scenarioInfo);
#line hidden
            if ((TagHelper.ContainsIgnoreTag(tagsOfScenario) || TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 30
  testRunner.Given("первый вектор равен (1, 2)", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Дано ");
#line hidden
#line 31
  testRunner.And("второй вектор равен (1, 2)", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "И ");
#line hidden
#line 32
  testRunner.When("происходит сравнение хэш-кодов", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Когда ");
#line hidden
#line 33
  testRunner.Then("хэш-коды векторов равны", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Тогда ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [Xunit.SkippableFactAttribute(DisplayName="Векторы с разными размерами имеют разные хэш-коды")]
        [Xunit.TraitAttribute("FeatureTitle", "VectorAction")]
        [Xunit.TraitAttribute("Description", "Векторы с разными размерами имеют разные хэш-коды")]
        public void ВекторыСРазнымиРазмерамиИмеютРазныеХэш_Коды()
        {
            string[] tagsOfScenario = ((string[])(null));
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Векторы с разными размерами имеют разные хэш-коды", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 35
this.ScenarioInitialize(scenarioInfo);
#line hidden
            if ((TagHelper.ContainsIgnoreTag(tagsOfScenario) || TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 36
  testRunner.Given("первый вектор равен (1, 2)", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Дано ");
#line hidden
#line 37
  testRunner.And("второй вектор равен (1)", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "И ");
#line hidden
#line 38
  testRunner.When("происходит сравнение хэш-кодов", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Когда ");
#line hidden
#line 39
  testRunner.Then("хэш-коды векторов не равны", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Тогда ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [Xunit.SkippableFactAttribute(DisplayName="Равенство вектора с объектом другого типа возвращает false")]
        [Xunit.TraitAttribute("FeatureTitle", "VectorAction")]
        [Xunit.TraitAttribute("Description", "Равенство вектора с объектом другого типа возвращает false")]
        public void РавенствоВектораСОбъектомДругогоТипаВозвращаетFalse()
        {
            string[] tagsOfScenario = ((string[])(null));
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Равенство вектора с объектом другого типа возвращает false", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 41
this.ScenarioInitialize(scenarioInfo);
#line hidden
            if ((TagHelper.ContainsIgnoreTag(tagsOfScenario) || TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 42
  testRunner.Given("первый вектор равен (1, 2)", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Дано ");
#line hidden
#line 43
  testRunner.And("объект не является вектором", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "И ");
#line hidden
#line 44
  testRunner.When("происходит сравнение вектора с объектом", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Когда ");
#line hidden
#line 45
  testRunner.Then("результат равен false", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Тогда ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [Xunit.SkippableFactAttribute(DisplayName="Сложение двух векторов неверно для исключения")]
        [Xunit.TraitAttribute("FeatureTitle", "VectorAction")]
        [Xunit.TraitAttribute("Description", "Сложение двух векторов неверно для исключения")]
        public void СложениеДвухВекторовНеверноДляИсключения()
        {
            string[] tagsOfScenario = ((string[])(null));
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Сложение двух векторов неверно для исключения", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 47
this.ScenarioInitialize(scenarioInfo);
#line hidden
            if ((TagHelper.ContainsIgnoreTag(tagsOfScenario) || TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 48
  testRunner.Given("первый вектор равен (5, 3)", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Дано ");
#line hidden
#line 49
  testRunner.And("второй вектор равен (7)", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "И ");
#line hidden
#line 50
  testRunner.When("происходит сложение векторов", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Когда ");
#line hidden
#line 51
  testRunner.Then("получаем исключение", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Тогда ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "3.9.0.0")]
        [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
        public class FixtureData : System.IDisposable
        {
            
            public FixtureData()
            {
                VectorActionFeature.FeatureSetup();
            }
            
            void System.IDisposable.Dispose()
            {
                VectorActionFeature.FeatureTearDown();
            }
        }
    }
}
#pragma warning restore
#endregion

// --- НАЧАЛО ФАЙЛА UnitTestProject1\UnitTest1.cs ---
using Microsoft.VisualStudio.TestTools.UnitTesting;
// Подключаем пространство имен основного проекта
using kalori; // Убедитесь, что пространство имен вашего проекта kalori
using System;

namespace UnitTestProject1
{
    [TestClass]
    public class Form1CalculatorTests // Имя класса тестов
    {
        // Погрешность для сравнения чисел с плавающей точкой
        private const double Delta = 0.01;

        #region CalculateBmrMacros Tests (Тесты БЖУ) - Восстановлены

        [TestMethod]
        [TestCategory("KaloriCalculator_BMR")]
        [Description("Тест БЖУ: Мужчина, Сидячий")]
        public void CalculateBmrMacros_MaleSedentary_ReturnsCorrectValues()
        {
            // Arrange: Задаем входные данные
            int age = 30; double height = 180; double weight = 85; string gender = "Мужской"; string activity = "Сидячий";
            // Ожидаемые результаты (пересчитаны по формулам в коде)
            // BMR = (10 * 85) + (6.25 * 180) - (5 * 30) + 5 = 850 + 1125 - 150 + 5 = 1830
            // TDEE = 1830 * 1.2 = 2196
            // Protein = (2196 * 0.30) / 4 = 658.8 / 4 = 164.7
            // Fat = (2196 * 0.30) / 9 = 658.8 / 9 = 73.2
            // Carbs = (2196 * 0.40) / 4 = 878.4 / 4 = 219.6
            double expectedBmr = 1830.0; double expectedTdee = 2196.0;
            double expectedProtein = 164.7; double expectedFat = 73.2; double expectedCarbs = 219.6;

            // Act: Вызываем тестируемый метод
            BmrMacroResult result = Form1.Calculator.CalculateBmrMacros(age, height, weight, gender, activity);

            // Assert: Сравниваем фактический результат с ожидаемым
            Assert.AreEqual(expectedBmr, result.Bmr, Delta, "BMR");
            Assert.AreEqual(expectedTdee, result.Tdee, Delta, "TDEE");
            Assert.AreEqual(expectedProtein, result.ProteinGrams, Delta, "Белки");
            Assert.AreEqual(expectedFat, result.FatGrams, Delta, "Жиры");
            Assert.AreEqual(expectedCarbs, result.CarbGrams, Delta, "Углеводы");
        }

        [TestMethod]
        [TestCategory("KaloriCalculator_BMR")]
        [Description("Тест БЖУ: Женщина, Умеренная активность")]
        public void CalculateBmrMacros_FemaleModerate_ReturnsCorrectValues()
        {
            // Arrange
            int age = 25; double height = 165; double weight = 60; string gender = "Женский"; string activity = "Умеренная активность";
            // BMR = (10 * 60) + (6.25 * 165) - (5 * 25) - 161 = 600 + 1031.25 - 125 - 161 = 1345.25
            // TDEE = 1345.25 * 1.55 = 2085.1375
            // Protein = (2085.1375 * 0.30) / 4 = 625.54125 / 4 = 156.385... ~ 156.4
            // Fat = (2085.1375 * 0.30) / 9 = 625.54125 / 9 = 69.504... ~ 69.5
            // Carbs = (2085.1375 * 0.40) / 4 = 834.055 / 4 = 208.513... ~ 208.5
            double expectedBmr = 1345.25; double expectedTdee = 2085.14; // Округлено до 2 знаков для TDEE
            double expectedProtein = 156.4; double expectedFat = 69.5; double expectedCarbs = 208.5; // Округлено до 1 знака

            // Act
            BmrMacroResult result = Form1.Calculator.CalculateBmrMacros(age, height, weight, gender, activity);

            // Assert
            Assert.AreEqual(expectedBmr, result.Bmr, Delta, "BMR (Жен)");
            Assert.AreEqual(expectedTdee, result.Tdee, Delta, "TDEE (Жен)");
            Assert.AreEqual(expectedProtein, result.ProteinGrams, Delta, "Белки (Жен)");
            Assert.AreEqual(expectedFat, result.FatGrams, Delta, "Жиры (Жен)");
            Assert.AreEqual(expectedCarbs, result.CarbGrams, Delta, "Углеводы (Жен)");
        }

        [TestMethod]
        [TestCategory("KaloriCalculator_BMR")]
        [Description("Тест БЖУ: Исключение - Нулевой возраст")]
        public void CalculateBmrMacros_ZeroAge_ThrowsArgumentOutOfRangeException()
        {
            // Assert
            // Проверяем, что вызов метода с age=0 бросает исключение ArgumentOutOfRangeException
            // и что имя параметра в исключении равно "age"
            var ex = Assert.ThrowsException<ArgumentOutOfRangeException>(
                () => Form1.Calculator.CalculateBmrMacros(0, 170, 70, "Мужской", "Сидячий"));
            Assert.AreEqual("age", ex.ParamName);
        }

        [TestMethod]
        [TestCategory("KaloriCalculator_BMR")]
        [Description("Тест БЖУ: Исключение - Отрицательный рост")]
        public void CalculateBmrMacros_NegativeHeight_ThrowsArgumentOutOfRangeException()
        {
            // Assert
            var ex = Assert.ThrowsException<ArgumentOutOfRangeException>(
                () => Form1.Calculator.CalculateBmrMacros(30, -170, 70, "Мужской", "Сидячий"));
            Assert.AreEqual("heightCm", ex.ParamName);
        }

        [TestMethod]
        [TestCategory("KaloriCalculator_BMR")]
        [Description("Тест БЖУ: Исключение - Нулевой вес")]
        public void CalculateBmrMacros_ZeroWeight_ThrowsArgumentOutOfRangeException()
        {
            // Assert
            var ex = Assert.ThrowsException<ArgumentOutOfRangeException>(
                () => Form1.Calculator.CalculateBmrMacros(30, 170, 0, "Мужской", "Сидячий"));
            Assert.AreEqual("weightKg", ex.ParamName);
        }

        [TestMethod]
        [TestCategory("KaloriCalculator_BMR")]
        [Description("Тест БЖУ: Исключение - Некорректный пол")]
        public void CalculateBmrMacros_InvalidGender_ThrowsArgumentException()
        {
            // Assert
            // Проверяем, что вызов с некорректным полом бросает ArgumentException
            var ex = Assert.ThrowsException<ArgumentException>(
                () => Form1.Calculator.CalculateBmrMacros(30, 170, 70, "Не указан", "Сидячий"));
            // Проверяем, что имя параметра указано верно (если оно есть в исключении)
            Assert.AreEqual("gender", ex.ParamName); // Убедимся, что имя параметра передается
        }

        [TestMethod]
        [TestCategory("KaloriCalculator_BMR")]
        [Description("Тест БЖУ: Исключение - Некорректная активность")]
        public void CalculateBmrMacros_InvalidActivity_ThrowsArgumentException()
        {
            // Assert
            var ex = Assert.ThrowsException<ArgumentException>(
                () => Form1.Calculator.CalculateBmrMacros(30, 170, 70, "Женский", "Лежание на диване"));
            Assert.AreEqual("activityLevel", ex.ParamName); // Убедимся, что имя параметра передается
        }

        [TestMethod]
        [TestCategory("KaloriCalculator_BMR")]
        [Description("Тест БЖУ: Исключение - Пустая строка активности")]
        public void CalculateBmrMacros_EmptyActivity_ThrowsArgumentException()
        {
            // Assert
            var ex = Assert.ThrowsException<ArgumentException>(
                () => Form1.Calculator.CalculateBmrMacros(30, 170, 70, "Мужской", ""));
            Assert.AreEqual("activityLevel", ex.ParamName);
        }

        #endregion

        #region CalculateWaterIntake Tests (Тесты Воды) - Восстановлены

        [TestMethod]
        [TestCategory("KaloriCalculator_Water")]
        [Description("Тест Воды: Корректный вес")]
        public void CalculateWaterIntake_ValidWeight_ReturnsCorrectLiters()
        {
            // Arrange
            double weight = 75.5;
            // Ожидаемый результат: (75.5 * 33) / 1000 = 2491.5 / 1000 = 2.4915
            double expectedLiters = 2.49; // Округлено до 2 знаков

            // Act
            double result = Form1.Calculator.CalculateWaterIntake(weight);

            // Assert
            Assert.AreEqual(expectedLiters, result, Delta, "Расчет воды");
        }

        [TestMethod]
        [TestCategory("KaloriCalculator_Water")]
        [Description("Тест Воды: Другой корректный вес")]
        public void CalculateWaterIntake_AnotherValidWeight_ReturnsCorrectLiters()
        {
            // Arrange
            double weight = 50.0;
            // Ожидаемый результат: (50.0 * 33) / 1000 = 1650 / 1000 = 1.65
            double expectedLiters = 1.65;

            // Act
            double result = Form1.Calculator.CalculateWaterIntake(weight);

            // Assert
            Assert.AreEqual(expectedLiters, result, Delta, "Расчет воды для 50кг");
        }


        [TestMethod]
        [TestCategory("KaloriCalculator_Water")]
        [Description("Тест Воды: Исключение - Нулевой вес")]
        public void CalculateWaterIntake_ZeroWeight_ThrowsArgumentOutOfRangeException()
        {
            // Assert
            var ex = Assert.ThrowsException<ArgumentOutOfRangeException>(
                () => Form1.Calculator.CalculateWaterIntake(0));
            Assert.AreEqual("weightKg", ex.ParamName);
        }

        [TestMethod]
        [TestCategory("KaloriCalculator_Water")]
        [Description("Тест Воды: Исключение - Отрицательный вес")]
        public void CalculateWaterIntake_NegativeWeight_ThrowsArgumentOutOfRangeException()
        {
            // Assert
            var ex = Assert.ThrowsException<ArgumentOutOfRangeException>(
                () => Form1.Calculator.CalculateWaterIntake(-10.5));
            Assert.AreEqual("weightKg", ex.ParamName);
        }
        #endregion

        #region CalculateBmiAndObesityStatus Tests (Тесты ИМТ) - Проверены

        [TestMethod]
        [TestCategory("KaloriCalculator_BMI")]
        [Description("Тест ИМТ: Статус Норма")]
        public void CalculateBmi_NormalWeight_ReturnsCorrectBmiAndStatus()
        {
            // Arrange
            double height = 175; double weight = 70;
            // BMI = 70 / (1.75 * 1.75) = 70 / 3.0625 = 22.857...
            double expectedBmi = 22.86; string expectedStatus = "Норма";
            // Act
            BmiResult result = Form1.Calculator.CalculateBmiAndObesityStatus(height, weight);
            // Assert
            Assert.AreEqual(expectedBmi, result.Bmi, Delta, "ИМТ (Норма)");
            Assert.AreEqual(expectedStatus, result.Status, "Статус (Норма)");
        }

        [TestMethod]
        [TestCategory("KaloriCalculator_BMI")]
        [Description("Тест ИМТ: Статус Ожирение 1 степени")]
        public void CalculateBmi_Obesity1_ReturnsCorrectBmiAndStatus()
        {
            // Arrange
            double height = 160; double weight = 80;
            // BMI = 80 / (1.6 * 1.6) = 80 / 2.56 = 31.25
            double expectedBmi = 31.25; string expectedStatus = "Ожирение 1 степени";
            // Act
            BmiResult result = Form1.Calculator.CalculateBmiAndObesityStatus(height, weight);
            // Assert
            Assert.AreEqual(expectedBmi, result.Bmi, Delta, "ИМТ (Ожирение 1)");
            Assert.AreEqual(expectedStatus, result.Status, "Статус (Ожирение 1)");
        }

        [TestMethod]
        [TestCategory("KaloriCalculator_BMI")]
        [Description("Тест ИМТ: Статус Недостаточная масса тела")]
        public void CalculateBmi_Underweight_ReturnsCorrectBmiAndStatus()
        {
            // Arrange
            double height = 180; double weight = 55;
            // BMI = 55 / (1.8 * 1.8) = 55 / 3.24 = 16.975...
            double expectedBmi = 16.98; string expectedStatus = "Недостаточная масса тела (дефицит)";
            // Act
            BmiResult result = Form1.Calculator.CalculateBmiAndObesityStatus(height, weight);
            // Assert
            Assert.AreEqual(expectedBmi, result.Bmi, Delta, "ИМТ (Дефицит)");
            Assert.AreEqual(expectedStatus, result.Status, "Статус (Дефицит)");
        }

        [TestMethod]
        [TestCategory("KaloriCalculator_BMI")]
        [Description("Тест ИМТ: Статус Выраженный дефицит")]
        public void CalculateBmi_SevereUnderweight_ReturnsCorrectBmiAndStatus()
        {
            // Arrange
            double height = 170; double weight = 45;
            // BMI = 45 / (1.7 * 1.7) = 45 / 2.89 = 15.57...
            double expectedBmi = 15.57; string expectedStatus = "Выраженный дефицит массы тела";
            // Act
            BmiResult result = Form1.Calculator.CalculateBmiAndObesityStatus(height, weight);
            // Assert
            Assert.AreEqual(expectedBmi, result.Bmi, Delta, "ИМТ (Выр. дефицит)");
            Assert.AreEqual(expectedStatus, result.Status, "Статус (Выр. дефицит)");
        }


        [TestMethod]
        [TestCategory("KaloriCalculator_BMI")]
        [Description("Тест ИМТ: Граница Норма/Предожирение (BMI ровно 25.0)")]
        public void CalculateBmi_BorderlineOverweight_ReturnsCorrectBmiAndStatus()
        {
            // Arrange: Подбираем вес для BMI = 25.0 при росте 180 см
            // weight = BMI * height^2 = 25.0 * (1.8 * 1.8) = 25.0 * 3.24 = 81.0
            double height = 180; double weight = 81;
            double expectedBmi = 25.0; string expectedStatus = "Избыточная масса тела (предожирение)"; // BMI >= 25 это уже предожирение
            // Act
            BmiResult result = Form1.Calculator.CalculateBmiAndObesityStatus(height, weight);
            // Assert
            Assert.AreEqual(expectedBmi, result.Bmi, Delta, "ИМТ (Граница 25.0)");
            Assert.AreEqual(expectedStatus, result.Status, "Статус (Граница 25.0)");
        }

        [TestMethod]
        [TestCategory("KaloriCalculator_BMI")]
        [Description("Тест ИМТ: Граница Предожирение/Ожирение 1 (BMI ровно 30.0)")]
        public void CalculateBmi_BorderlineObesity1_ReturnsCorrectBmiAndStatus()
        {
            // Arrange: Подбираем вес для BMI = 30.0 при росте 170 см
            // weight = BMI * height^2 = 30.0 * (1.7 * 1.7) = 30.0 * 2.89 = 86.7
            double height = 170; double weight = 86.7;
            double expectedBmi = 30.0; string expectedStatus = "Ожирение 1 степени"; // BMI >= 30 это уже ожирение 1
            // Act
            BmiResult result = Form1.Calculator.CalculateBmiAndObesityStatus(height, weight);
            // Assert
            Assert.AreEqual(expectedBmi, result.Bmi, Delta, "ИМТ (Граница 30.0)");
            Assert.AreEqual(expectedStatus, result.Status, "Статус (Граница 30.0)");
        }

        [TestMethod]
        [TestCategory("KaloriCalculator_BMI")]
        [Description("Тест ИМТ: Исключение - Нулевой рост")]
        public void CalculateBmi_ZeroHeight_ThrowsArgumentOutOfRangeException() // Проверяем правильный тип исключения
        {
            // Assert
            var ex = Assert.ThrowsException<ArgumentOutOfRangeException>(
                () => Form1.Calculator.CalculateBmiAndObesityStatus(0, 60));
            Assert.AreEqual("heightCm", ex.ParamName);
        }

        [TestMethod]
        [TestCategory("KaloriCalculator_BMI")]
        [Description("Тест ИМТ: Исключение - Отрицательный рост")]
        public void CalculateBmi_NegativeHeight_ThrowsArgumentOutOfRangeException()
        {
            // Assert
            var ex = Assert.ThrowsException<ArgumentOutOfRangeException>(
                () => Form1.Calculator.CalculateBmiAndObesityStatus(-170, 70));
            Assert.AreEqual("heightCm", ex.ParamName);
        }


        [TestMethod]
        [TestCategory("KaloriCalculator_BMI")]
        [Description("Тест ИМТ: Исключение - Отрицательный вес")]
        public void CalculateBmi_NegativeWeight_ThrowsArgumentOutOfRangeException()
        {
            // Assert
            var ex = Assert.ThrowsException<ArgumentOutOfRangeException>(
                () => Form1.Calculator.CalculateBmiAndObesityStatus(170, -60.5));
            Assert.AreEqual("weightKg", ex.ParamName);
        }

        [TestMethod]
        [TestCategory("KaloriCalculator_BMI")]
        [Description("Тест ИМТ: Исключение - Нулевой вес")]
        public void CalculateBmi_ZeroWeight_ThrowsArgumentOutOfRangeException()
        {
            // Assert
            var ex = Assert.ThrowsException<ArgumentOutOfRangeException>(
                () => Form1.Calculator.CalculateBmiAndObesityStatus(170, 0));
            Assert.AreEqual("weightKg", ex.ParamName);
        }

        #endregion
    }
}
// --- КОНЕЦ ФАЙЛА UnitTestProject1\UnitTest1.cs ---
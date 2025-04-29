using System;
using System.Globalization;
using System.Windows.Forms;

namespace kalori
{
    public struct BmrMacroResult
    {
        public double Bmr { get; set; }
        public double Tdee { get; set; }
        public double ProteinGrams { get; set; }
        public double FatGrams { get; set; }
        public double CarbGrams { get; set; }
    }

    public struct BmiResult
    {
        public double Bmi { get; set; }
        public string Status { get; set; }
    }


    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            System.Threading.Thread.CurrentThread.CurrentCulture = new CultureInfo("ru-RU");
            System.Threading.Thread.CurrentThread.CurrentUICulture = new CultureInfo("ru-RU");
            InitializeComboBoxDefaults();
        }

        private void InitializeComboBoxDefaults()
        {
            if (cmbGender.Items.Count > 0) cmbGender.SelectedIndex = 0; 
            if (cmbActivityLevel.Items.Count > 0) cmbActivityLevel.SelectedIndex = 0; 
        }
        private void HideAllPanels()
        {
            panelBmr.Visible = false;
            panelWater.Visible = false;
            panelObesity.Visible = false;
        }

        private void ShowPanel(Panel panelToShow)
        {
            HideAllPanels();
            panelToShow.Visible = true;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            ShowPanel(panelBmr);
        }

        private void BtnShowBmrCalc_Click(object sender, EventArgs e)
        {
            ShowPanel(panelBmr);
        }

        private void BtnShowWaterCalc_Click(object sender, EventArgs e)
        {
            ShowPanel(panelWater);
        }

        private void BtnShowObesityCalc_Click(object sender, EventArgs e)
        {
            ShowPanel(panelObesity);
        }
        private void BtnCalculateBmr_Click(object sender, EventArgs e)
        {
            if (TryGetInt(txtBmrAge, "Возраст", out int age) &&
                TryGetDouble(txtBmrHeight, "Рост", out double height) &&
                TryGetDouble(txtBmrWeight, "Вес", out double weight) &&
                TryGetComboBoxSelection(cmbGender, "Пол", out string gender) &&
                TryGetComboBoxSelection(cmbActivityLevel, "Уровень активности", out string activity))
            {
                try
                {
                    var result = Calculator.CalculateBmrMacros(age, height, weight, gender, activity);
                    lblBmrResult.Text = $"Базовый метаболизм (BMR): {result.Bmr:F0} ккал";
                    lblTdeeResult.Text = $"Суточная потребность (TDEE): {result.Tdee:F0} ккал";
                    lblProteinResult.Text = $"Белки: {result.ProteinGrams:F1} г";
                    lblFatResult.Text = $"Жиры: {result.FatGrams:F1} г";
                    lblCarbsResult.Text = $"Углеводы: {result.CarbGrams:F1} г";
                }
                catch (Exception ex) 
                {
                    HandleCalculationError(ex, ResetBmrLabels, SetErrorBmrLabels);
                }
            }
            else { ResetBmrLabels(); } 
        }

        private void BtnCalculateWater_Click(object sender, EventArgs e)
        {
            if (TryGetDouble(txtWaterWeight, "Вес", out double weight))
            {
                try
                {
                    double waterLiters = Calculator.CalculateWaterIntake(weight);
                    lblWaterResult.Text = $"Рекомендуемое потребление воды: {waterLiters:F1} л";
                }
                catch (Exception ex)
                {
                    HandleCalculationError(ex, ResetWaterLabel, SetErrorWaterLabel);
                }
            }
            else { ResetWaterLabel(); }
        }

        private void BtnCalculateObesity_Click(object sender, EventArgs e)
        {
            if (TryGetDouble(txtObesityHeight, "Рост", out double height) &&
                TryGetDouble(txtObesityWeight, "Вес", out double weight))
            {
                try
                {
                    var result = Calculator.CalculateBmiAndObesityStatus(height, weight);
                    lblBmiResult.Text = $"Индекс Массы Тела (ИМТ): {result.Bmi:F1}";
                    lblObesityStatusResult.Text = $"Статус: {result.Status}";
                }
                catch (Exception ex)
                {
                    HandleCalculationError(ex, ResetObesityLabels, SetErrorObesityLabels);
                }
            }
            else { ResetObesityLabels(); }
        }

        // --- Вспомогательные методы валидации (Без лишних присваиваний!) ---
        private bool TryGetDouble(TextBox textBox, string fieldName, out double value)
        {
            value = 0; // Инициализация обязательна для out параметра
            // Используем CultureInfo.InvariantCulture для парсинга точки как десятичного разделителя
            if (double.TryParse(textBox.Text.Replace(',', '.'), NumberStyles.Any, CultureInfo.InvariantCulture, out value) && value > 0)
            {
                return true; // Успех
            }
            // Если парсинг не удался или число не положительное
            MessageBox.Show($"Пожалуйста, введите корректное положительное числовое значение для поля '{fieldName}'.", "Ошибка ввода", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            textBox.Focus();
            textBox.SelectAll();
            return false; // Неудача
        }

        private bool TryGetInt(TextBox textBox, string fieldName, out int value)
        {
            value = 0; // Инициализация
            // Используем CultureInfo.InvariantCulture на случай, если разделители групп мешают
            if (int.TryParse(textBox.Text, NumberStyles.Integer, CultureInfo.InvariantCulture, out value) && value > 0)
            {
                return true; // Успех
            }
            MessageBox.Show($"Пожалуйста, введите корректное положительное целое значение для поля '{fieldName}'.", "Ошибка ввода", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            textBox.Focus();
            textBox.SelectAll();
            return false; // Неудача
        }

        private bool TryGetComboBoxSelection(ComboBox comboBox, string fieldName, out string selectedValue)
        {
            // Получаем выбранный элемент как строку
            selectedValue = comboBox.SelectedItem?.ToString();
            // Проверяем, что строка не пуста и не состоит только из пробелов
            if (!string.IsNullOrWhiteSpace(selectedValue))
            {
                return true; // Успех
            }
            // Если выбор не сделан
            MessageBox.Show($"Пожалуйста, выберите значение для поля '{fieldName}'.", "Ошибка ввода", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            comboBox.Focus();
            selectedValue = null; // Сброс значения при ошибке
            return false; // Неудача
        }


        // --- ИСПРАВЛЕННАЯ Обработка ошибок расчета ---
        private void HandleCalculationError(Exception ex, Action resetAction, Action setErrorAction)
        {
            string message;
            MessageBoxIcon icon = MessageBoxIcon.Error; // По умолчанию - серьезная ошибка

            // Проверка на ArgumentOutOfRangeException
            if (ex is ArgumentOutOfRangeException argEx)
            {
                message = $"Ошибка ввода: Поле '{argEx.ParamName}' имеет недопустимое значение ({argEx.ActualValue}). {argEx.Message.Split('.')[0]}.";
                icon = MessageBoxIcon.Warning;
                resetAction?.Invoke();
            }
            // Проверка на общий ArgumentException
            else if (ex is ArgumentException generalArgEx) // Используем другое имя переменной или кастуем внутри
            {
                // Проверяем, есть ли имя параметра в этом ArgumentException
                if (!string.IsNullOrEmpty(generalArgEx.ParamName))
                {
                    // Если есть имя параметра (например, от некорректного пола/активности)
                    message = $"Ошибка ввода: {generalArgEx.Message} (Поле: '{generalArgEx.ParamName}')";
                }
                else
                {
                    // Если имя параметра не указано в исключении
                    message = $"Ошибка ввода: {generalArgEx.Message}";
                }
                icon = MessageBoxIcon.Warning; // Ошибка ввода - предупреждение
                resetAction?.Invoke(); // Сбросить метки
            }
            // Любые другие непредвиденные исключения
            else
            {
                message = $"Непредвиденная ошибка расчета: {ex.Message}";
                // Оставляем icon = MessageBoxIcon.Error
                setErrorAction?.Invoke(); // Поставить метки в состояние ошибки
            }
            MessageBox.Show(message, "Ошибка", MessageBoxButtons.OK, icon);
        }


        // --- Методы сброса/установки ошибки меток ---
        private void ResetBmrLabels() { lblBmrResult.Text = "Баз. метаболизм (BMR):"; lblTdeeResult.Text = "Сут. потребность (TDEE):"; lblProteinResult.Text = "Белки:"; lblFatResult.Text = "Жиры:"; lblCarbsResult.Text = "Углеводы:"; }
        private void SetErrorBmrLabels() { lblBmrResult.Text = "BMR: Ошибка"; lblTdeeResult.Text = "TDEE: Ошибка"; lblProteinResult.Text = "Белки: Ошибка"; lblFatResult.Text = "Жиры: Ошибка"; lblCarbsResult.Text = "Углеводы: Ошибка"; }
        private void ResetWaterLabel() { lblWaterResult.Text = "Реком. потребление воды:"; }
        private void SetErrorWaterLabel() { lblWaterResult.Text = "Реком. потребление воды: Ошибка"; }
        private void ResetObesityLabels() { lblBmiResult.Text = "Индекс Массы Тела (ИМТ):"; lblObesityStatusResult.Text = "Статус:"; }
        private void SetErrorObesityLabels() { lblBmiResult.Text = "ИМТ: Ошибка"; lblObesityStatusResult.Text = "Статус: Ошибка"; }


        // --- Вложенный статический класс Calculator ---
        public static class Calculator
        {
            // Расчет BMR/TDEE/БЖУ
            public static BmrMacroResult CalculateBmrMacros(int age, double heightCm, double weightKg, string gender, string activityLevel)
            {
                // Внутренняя валидация
                if (age <= 0) throw new ArgumentOutOfRangeException(nameof(age), age, "Возраст должен быть положительным числом.");
                if (heightCm <= 0) throw new ArgumentOutOfRangeException(nameof(heightCm), heightCm, "Рост должен быть положительным числом.");
                if (weightKg <= 0) throw new ArgumentOutOfRangeException(nameof(weightKg), weightKg, "Вес должен быть положительным числом.");
                if (gender != "Мужской" && gender != "Женский") throw new ArgumentException("Некорректный пол.", nameof(gender)); // Указываем параметр
                if (string.IsNullOrWhiteSpace(activityLevel)) throw new ArgumentException("Уровень активности не выбран.", nameof(activityLevel)); // Указываем параметр

                // Формулы BMR (Харриса-Бенедикта, пересмотренная)
                double bmr = (gender == "Мужской")
                           ? (9.99 * weightKg) + (6.25 * heightCm) - (4.92 * age) + 5.0
                           : (9.99 * weightKg) + (6.25 * heightCm) - (4.92 * age) - 161.0;

                // BMR не может быть отрицательным (хотя по формуле почти невозможно при полож. вводе)
                if (bmr < 0) bmr = 0;

                // Коэффициент активности (TDEE = BMR * activityFactor)
                double activityFactor;
                switch (activityLevel)
                {
                    case "Сидячий": activityFactor = 1.2; break;
                    case "Легкая активность": activityFactor = 1.375; break;
                    case "Умеренная активность": activityFactor = 1.55; break;
                    case "Высокая активность": activityFactor = 1.725; break;
                    case "Очень высокая активность": activityFactor = 1.9; break;
                    default:
                        // Если сюда попали - ошибка в логике или значениях ComboBox
                        throw new ArgumentException($"Неизвестный уровень активности: '{activityLevel}'.", nameof(activityLevel));
                }

                // Расчет TDEE
                double tdee = bmr * activityFactor;

                // Расчет макронутриентов (примерное соотношение 30%Б / 30%Ж / 40%У)
                // Калорийность: Белки и Углеводы ~4 ккал/г, Жиры ~9 ккал/г
                double proteinGrams = (tdee * 0.30) / 4.0;
                double fatGrams = (tdee * 0.30) / 9.0;
                double carbGrams = (tdee * 0.40) / 4.0;

                return new BmrMacroResult
                {
                    Bmr = bmr,
                    Tdee = tdee,
                    ProteinGrams = proteinGrams,
                    FatGrams = fatGrams,
                    CarbGrams = carbGrams
                };
            }

            // Расчет рекомендуемого потребления воды
            public static double CalculateWaterIntake(double weightKg)
            {
                // Валидация
                if (weightKg <= 0) throw new ArgumentOutOfRangeException(nameof(weightKg), weightKg, "Вес должен быть положительным числом.");

                // Формула: ~30-35 мл на кг веса. Возьмем 33 мл.
                // Результат в литрах.
                return (weightKg * 33.0) / 1000.0;
            }

            // Расчет ИМТ и статуса ожирения
            public static BmiResult CalculateBmiAndObesityStatus(double heightCm, double weightKg)
            {
                // Внутренняя валидация
                if (heightCm <= 0) throw new ArgumentOutOfRangeException(nameof(heightCm), heightCm, "Рост должен быть положительным числом.");
                if (weightKg <= 0) throw new ArgumentOutOfRangeException(nameof(weightKg), weightKg, "Вес должен быть положительным числом.");

                // Переводим рост в метры
                double heightM = heightCm / 100.0;

                // Формула ИМТ = вес(кг) / (рост(м))^2
                double bmi = weightKg / (heightM * heightM);

                // Определение статуса на основе ИМТ (классификация ВОЗ)
                string status;
                if (bmi < 16.0) status = "Выраженный дефицит массы тела";
                else if (bmi < 18.5) status = "Недостаточная масса тела (дефицит)";
                else if (bmi < 25.0) status = "Норма";
                else if (bmi < 30.0) status = "Избыточная масса тела (предожирение)";
                else if (bmi < 35.0) status = "Ожирение 1 степени";
                else if (bmi < 40.0) status = "Ожирение 2 степени";
                else status = "Ожирение 3 степени (морбидное)"; // bmi >= 40.0

                return new BmiResult { Bmi = bmi, Status = status };
            }
        } // Конец Calculator
    } // Конец Form1
} // Конец namespace kalori
  // --- КОНЕЦ ФАЙЛА kalori\Form1.cs ---
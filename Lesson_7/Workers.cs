using System;


namespace Lesson_7
{
    public struct Worker
    {
        /// <summary>
        /// Порядковый номер
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Дата и время записи текста
        /// </summary>
        public DateTime TimeDate { get; set; }
        /// <summary>
        /// Ф.И.О
        /// </summary>
        public string FullName { get; set; }
        /// <summary>
        /// Возраст
        /// </summary>
        public string Age { get; set; }
        /// <summary>
        /// Рост
        /// </summary>
        public string Growth { get; set; }
        /// <summary>
        /// Дата рождения
        /// </summary>
        public string DateOfBirth { get; set; }
        /// <summary>
        /// Место рождения
        /// </summary>
        public string PlaceOfBirth { get; set; }
        /// <summary>
        /// Вывод на экран
        /// </summary>
        public string Print()
        {
            return $"Номер: {this.Id} " +
                   $"Дата и время: {this.TimeDate}" +
                   $" Ф.И.О: {this.FullName} " +
                   $"Возраст: {this.Age} " +
                   $"Рост:{this.Growth} " +
                   $"Дата рождения: {this.DateOfBirth} " +
                   $"Место рождения: {this.PlaceOfBirth}";
        }
        /// <summary>
        /// Создание сотрудников
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="TimeDate"></param>
        /// <param name="FullName"></param>
        /// <param name="Age"></param>
        /// <param name="Growth"></param>
        /// <param name="DateOfBirth"></param>
        /// <param name="PlaceOfBirth"></param>
        public Worker(int Id, DateTime TimeDate, string FullName, string Age, string Growth, string DateOfBirth, string PlaceOfBirth)
        {
            this.Id = Id;
            this.TimeDate = TimeDate;
            this.FullName = FullName;
            this.Age = Age;
            this.Growth = Growth;
            this.DateOfBirth = DateOfBirth;
            this.PlaceOfBirth = PlaceOfBirth;
        }
    }
}

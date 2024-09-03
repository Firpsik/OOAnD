#language: ru

Функция: VectorAction

Сценарий: Сравнение двух векторов верно
	Дано первый вектор равен (5, 3)
	И второй вектор равен (5, 3)
	Когда происходит сравнение векторов
	Тогда получаем (true)

Сценарий: Сравнение двух векторов неверно
	Дано первый вектор равен (5, 3)
	И второй вектор равен (7, 3)
	Когда происходит сравнение векторов
	Тогда получаем (false)

Сценарий: Сравнение двух векторов невозможно
	Дано первый вектор равен (5, 3)
	И второй вектор равен null
	Когда происходит сравнение векторов
	Тогда возникает ошибка

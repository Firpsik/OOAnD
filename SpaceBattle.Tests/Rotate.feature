Функция: Поворот

Сценарий: Игровой объект может вращаться вокруг собственной оси 
Дано космический корабль имеет угол наклона 45 град к оси OX
И имеет мгновенную угловую скорость 45 град
Когда происходит вращение вокруг собственной оси
Тогда угол наклона космического корабля к оси OX составляет 90 град

Сценарий: Если невозможно определить угол наклона к оси OX космического корабля, то вращение вокруг собственной оси  невозможно 
Дано космический корабль, угол наклона которого невозможно определить
И имеет мгновенную угловую скорость 45 град
Когда происходит вращение вокруг собственной оси
Тогда возникает ошибка Exception

Сценарий: Если невозможно определить мгновенную угловую скорость космического корабля, то вращение вокруг собственной оси  невозможно 
Дано космический корабль имеет угол наклона 45 град к оси OX
И мгновенную угловую скорость невозможно определить
Когда происходит вращение вокруг собственной оси
Тогда возникает ошибка Exception 

Сценарий: Если невозможно установить новый угол наклона космического корабля космического корабля, то вращение вокруг собственной оси  невозможно 
Дано космический корабль имеет угол наклона 45 град к оси OX
И имеет мгновенную угловую скорость 45 град
И невозможно изменить угол наклона к оси OX космического корабля
Когда происходит вращение вокруг собственной оси
Тогда возникает ошибка Exception

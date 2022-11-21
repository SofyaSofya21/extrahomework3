// 6. Написать 2 функции для работы с массивом: AddToArray И RemoveFromArray – 
// первая добавляет к числовому массиву значение, тем самым увеличивая массив, 
// а вторая удаляет элемент под нужным индексом и уменьшает массив на 1.


int[] personalArray = new int[ReadInt("Сколько элементов будет в массиве? ")];
Console.WriteLine($"Количество элементов во введенном массиве: {personalArray.Length}");

personalArray = ReadArray(personalArray.Length);

Console.Write("Введите число, которое вы хотите добавить в массив: ");
int addNumber = Convert.ToInt32(Console.ReadLine());
Console.Write($"На какую позицию добавить новый элемент? (введите число от 0 до {personalArray.Length}) ");
int newInd = Convert.ToInt32(Console.ReadLine());
personalArray = AddToArray(personalArray, addNumber, newInd);
PrintArray(personalArray);

Console.Write($"Элемент под каким номером вы хотите убрать? (введите число от 0 до {personalArray.Length-1}) ");
int deleteInd = Convert.ToInt32(Console.ReadLine());
personalArray = RemoveFromArray(personalArray, deleteInd);
PrintArray(personalArray);



// AddToArray
int[] AddToArray(int[] array, int newNumber, int newPosIndex)
{
    int i = 0;
    int[] arrayNew = new int[array.Length + 1];
    for (i = 0; i < arrayNew.Length; i++)
    {
        if (i == newPosIndex)
        {
            arrayNew[i] = newNumber;
            for (int j = i + 1; j < arrayNew.Length; j++)
            {
                arrayNew[j] = array[j - 1];
            }
            break;
        }
        else
        {
            arrayNew[i] = array[i];
        }
    }
    return arrayNew;
}

// поиск в массиве индекса искомого значения
int IndexOf(int[] array, int find)
{
    int i = 0;
    int position = -1;
    for (i = 0; i < array.Length; i++)
    {
        if (array[i] == find)
        {
            position = i;
            break;
        }
    }
    return position;
}

//RemoveFromArray
int[] RemoveFromArray(int[] array, int removeNumbIndex)
{
    int i = 0;
    int[] arrayNew = new int[array.Length - 1];
    for (i = 0; i < arrayNew.Length; i++)
    {
        if (i == removeNumbIndex)
        {
            for (i = i; i < arrayNew.Length; i++) // как-то тупо, может не надо j вводить?
            {
                arrayNew[i] = array[i + 1];
            }
            ;
        }
        else
        {
            arrayNew[i] = array[i];
        }
    }
    return arrayNew;
}

//RemoveFromArray вариант с вводом числа
int[] RemoveFromArrayNumber(int[] array, int removeNumber)
{
    int i = 0;
    int[] arrayNew = new int[array.Length - 1];
    int removePosIndex = IndexOf(array, removeNumber);
    for (i = 0; i < arrayNew.Length; i++)
    {
        if (i == removePosIndex)
        {
            for (i = i; i < arrayNew.Length; i++) // как-то тупо, может не надо j вводить?
            {
                arrayNew[i] = array[i + 1];
            }
            ;
        }
        else
        {
            arrayNew[i] = array[i];
        }
    }
    return arrayNew;
}

// метод вывода массива
void PrintArray(int[] array)
{
    int count = array.Length;
    int i = 0;
    for (i = 0; i < count; i++)
    {
        Console.Write($"{array[i]} ");
    }
    Console.WriteLine();
}

// Метод считывания массива
int[] ReadArray(int length)
{
    int[] array = new int[length];
    Console.WriteLine("Введите элементы массива");
    for (int i = 0; i < length; i++)
    {
        array[i] = ReadInt("");
    }
    return array;
}

// метод считывания Int
int ReadInt(string message)
{
    Console.Write(message);
    return Convert.ToInt32(Console.ReadLine());
}

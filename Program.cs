using ConsoleApp12.Data;
using ConsoleApp12.Models;
using Microsoft.EntityFrameworkCore;

Console.OutputEncoding = System.Text.Encoding.UTF8;

using (var context = new ApplicationDbContext())
{
    context.Database.EnsureDeleted();

    context.Database.EnsureCreated();

    Console.WriteLine("База даних створена успішно!");

    // Create
    var users = new List<User>
    {
        new User { FirstName = "Іван", LastName = "Петренко", Age = 25 },
        new User { FirstName = "Марія", LastName = "Коваленко", Age = 30 },
        new User { FirstName = "Олександр", LastName = "Сидоренко", Age = 35 }
    };

    context.Users.AddRange(users);
    context.SaveChanges();
    Console.WriteLine("Користувачів додано до бази даних!");

    // Read
    Console.WriteLine("\nСписок всіх користувачів:");
    var allUsers = context.Users.OrderBy(u => u.Id).ToList();
    foreach (var user in allUsers)
    {
        Console.WriteLine($"Id: {user.Id}, Ім'я: {user.FirstName}, Прізвище: {user.LastName}, Вік: {user.Age}");
    }

    // Update
    var userToUpdate = context.Users.OrderBy(u => u.Id).First();
    userToUpdate.Age = 26;
    context.SaveChanges();
    Console.WriteLine($"\nКористувача оновлено: {userToUpdate.FirstName} тепер має вік {userToUpdate.Age}");

    // Delete
    var userToDelete = context.Users.OrderBy(u => u.Id).Last();
    context.Users.Remove(userToDelete);
    context.SaveChanges();
    Console.WriteLine($"\nКористувача видалено: {userToDelete.FirstName} {userToDelete.LastName}");

    Console.WriteLine("\nФінальний список користувачів:");
    allUsers = context.Users.OrderBy(u => u.Id).ToList();
    foreach (var user in allUsers)
    {
        Console.WriteLine($"Id: {user.Id}, Ім'я: {user.FirstName}, Прізвище: {user.LastName}, Вік: {user.Age}");
    }

    Console.WriteLine("\nОперації з базою даних завершено успішно!");
}

Console.WriteLine("\nНатисніть будь-яку клавішу для завершення...");
Console.ReadKey();
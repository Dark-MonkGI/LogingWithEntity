﻿using System;
using System.Data.Entity;
using System.Linq;

namespace LogingWithEntity.Model
{
    public class Context : DbContext
    {
        // Контекст настроен для использования строки подключения "Context" из файла конфигурации  
        // приложения (App.config или Web.config). По умолчанию эта строка подключения указывает на базу данных 
        // "LogingWithEntity.Model.Context" в экземпляре LocalDb. 
        // 
        // Если требуется выбрать другую базу данных или поставщик базы данных, измените строку подключения "Context" 
        // в файле конфигурации приложения.


        public Context()
            : base("name=Context")
        {
            Database.SetInitializer(new initializer());
        }


        // Добавьте DbSet для каждого типа сущности, который требуется включить в модель. Дополнительные сведения 
        // о настройке и использовании модели Code First см. в статье http://go.microsoft.com/fwlink/?LinkId=390109.

        // public virtual DbSet<MyEntity> MyEntities { get; set; }

        public virtual DbSet<UserVS> MyEntitiesTable { get; set; }
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}
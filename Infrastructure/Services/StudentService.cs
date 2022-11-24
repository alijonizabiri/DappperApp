using Dapper;
using Domain.Dtos;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class StudentService
    {
        private string _connectionString = "Server=127.0.0.1;Port=5432;Database=dapper_demo;User Id=postgres;Password=12345;";

        public List<Student> GetStudents()
        {
            using (var conn = new NpgsqlConnection(_connectionString))
            {
                var sql = $"SELECT * FROM students";

                return conn.Query<Student>(sql).ToList();
            }
        }

        public int InsertStudent(Student student)
        {
            using (var conn = new NpgsqlConnection(_connectionString))
            {
                var sql =
                    $"insert into students (name, surname, phone, address) VALUES " +
                    $"('{student.Name}', " +
                    $"'{student.Surname}', " +
                    $"'{student.Phone}', " +
                    $"'{student.Address}')";
                var result = conn.Execute(sql);

                return result;
            }
        }

        public int UpdateStudent(Student student)
        {
            using (var conn = new NpgsqlConnection(_connectionString))
            {
                var sql = 
                    $"UPDATE students SET " +
                    $"name = '{student.Name}', " +
                    $"surname = '{student.Surname}', " +
                    $"phone = '{student.Phone}', " +
                    $"address = '{student.Address}'" +
                    $"WHERE id = {student.Id}";

                var result = conn.Execute(sql);

                return result;
            }
        }

        public int DeleteStudent(int id)
        {
            using (var conn = new NpgsqlConnection(_connectionString))
            {
                var sql = $"DELETE FROM students WHERE id = {id}";

                var result = conn.Execute(sql);

                return result;
            }
        }

    }
}

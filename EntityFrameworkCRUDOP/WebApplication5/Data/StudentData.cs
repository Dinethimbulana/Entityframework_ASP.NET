using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication5.Data
{
    public class StudentData
    {
        public int Insert(Student domain)
        {
            int result = 0;

            using (BasicLayeredDBEntities db = new BasicLayeredDBEntities())
            {
                db.Students.Add(domain);
                result = db.SaveChanges();
                return result;
            }
        }

        public Student GetStudentByID(int studentSerial)
        {
            using (BasicLayeredDBEntities db = new BasicLayeredDBEntities())
            {
                var data = db.Students.Where(a => a.StudentSerial == studentSerial).SingleOrDefault();

                return data;
            }
        }

        public int Update(Student Detail)
        {
            int result = 0;
            using (BasicLayeredDBEntities db = new BasicLayeredDBEntities())
            {
                var obj = db.Students.SingleOrDefault(s => s.StudentSerial == Detail.StudentSerial);
                if (obj != null)
                {
                    obj.StudentID = Detail.StudentID;
                    obj.StudentName = Detail.StudentName;
                    obj.Grade = Detail.Grade;
                    obj.Telephone = Detail.Telephone;
                    obj.Gender = Detail.Gender;
                    result = db.SaveChanges(); //To save database

                }

                return result;
            }

        }

        public void DetailDelete(int StudentSerial)
        {
            BasicLayeredDBEntities db = new BasicLayeredDBEntities();
            var students = db.Students.FirstOrDefault(s => s.StudentSerial == StudentSerial);
            if (students != null)
            {
                db.Students.Remove(students);
                db.SaveChanges();
            }
        }

    }
}
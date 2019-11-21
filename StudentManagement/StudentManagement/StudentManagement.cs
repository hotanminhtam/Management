using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement
{
    class StudentManagement
    {
        public PM14008[] GetClasses()
        {
            var db = new OOPCSEntities();
            return db.PM14008.ToArray();
        }

        public void AddStudent(string Code, string Name, bool Gender, string Hometown)
        {
            var newStudent = new PM14008();
            newStudent.Code = Code;
            newStudent.Name = Name;
            newStudent.Gender = Gender;
            newStudent.Hometown = Hometown;

            var db = new OOPCSEntities();
            db.PM14008.Add(newStudent);
            db.SaveChanges();
        }

        public void EditStudent(int ID, string Code, string Name, Boolean Gender, string Hometown)
        {
            var db = new OOPCSEntities();
            var oldStudent = db.PM14008.Find(ID);

            oldStudent.Code = Code;
            oldStudent.Name = Name;
            oldStudent.Gender = Gender;
            oldStudent.Hometown = Hometown;

            db.Entry(oldStudent).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
        }

        public void DeleteStudent(int id)
        {
            var db = new OOPCSEntities();
            var student = db.PM14008.Find(id);
            db.PM14008.Remove(student);
            db.SaveChanges();
        }

        public PM14008 GetStudents(int id)
        {
            var db = new OOPCSEntities();
            var @student = db.PM14008.Find(id);
            return @student;
        }
    }
}

--1. Вывести все возможные пары строк преподавателей и групп.--
SELECT Surname, t.Name, g.Name as Group_Name
FROM Teachers t, Groups g;

--2. Вывести названия факультетов, фонд финансирования кафедр которых превышает фонд финансирования факультета.--
SELECT f.Name
FROM Faculties f, Departments d
WHERE d.FacultyId=f.Id
GROUP BY f.Name,f.Financing
HAVING f.Financing<SUM(d.Financing);

--3. Вывести фамилии кураторов групп и названия групп, которые они курируют.--
-- Это задание лучше выполнять через JOIN. Я бы так и сделала, но формально мы join-ы еще не изучали...--
SELECT c.curator_surname as Surname, g.Name
FROM Curators c, Groups g, GroupsCurators gc
WHERE g.Id=gc.GroupId and gc.CuratorId=c.Id;

--4. Вывести имена и фамилии преподавателей, которые читают лекции у группы “P107”.--
SELECT t.Name, t.Surname
FROM Teachers t, GroupsLectures gl, Groups g, Lectures l
WHERE t.Id=l.TeacherId and l.Id=gl.LectureId and gl.GroupId=g.Id and g.Name='P107';

--5. Вывести фамилии преподавателей и названия факультетов на которых они читают лекции.--
SELECT t.Surname, f.Name as Faculty
FROM Teachers t, Lectures l, GroupsLectures gl, Groups g, Departments d, Faculties f
WHERE t.Id=l.TeacherId and l.Id=gl.LectureId and gl.GroupId=g.Id and g.DepartmentId=d.Id and d.FacultyId=f.Id;

--6. Вывести названия кафедр и названия групп, которые к ним относятся.--
SELECT d.Name as Department, g.Name as Group_name
FROM Departments d, Groups g
WHERE d.Id=g.DepartmentId;

--7. Вывести названия дисциплин, которые читает преподаватель “Samantha Adams”.--
SELECT s.Name
FROM Subjects s, Lectures l, Teachers t
WHERE t.Id=l.TeacherId and l.SubjectId=s.Id and CONCAT(t.Name,t.Surname)='Samantha Adams';

--8. Вывести названия кафедр, на которых читается дисциплина 'Database Theory'--
SELECT d.Name
FROM Subjects s, Lectures l, GroupsLectures gl, Groups g, Departments d
WHERE s.Id=l.SubjectId and l.Id=gl.LectureId and gl.GroupId=g.Id and g.DepartmentId=d.Id and s.Name='Database Theory';

--9. Вывести названия групп, которые относятся к факультету “Computer Science”.--
SELECT g.Name
FROM Groups g, Departments d, Faculties f
WHERE d.Id=g.DepartmentId and d.FacultyId=f.Id and f.Name='Computer Science';

--10. Вывести названия групп 5-го курса, а также название факультетов, к которым они относятся.--
SELECT g.Name as Group_name, f.Name as Faculty
FROM Groups g, Departments d, Faculties f
WHERE d.Id=g.DepartmentId and d.FacultyId=f.Id and g.Year=5;

--11. Вывести полные имена преподавателей и лекции, которые они читают (названия дисциплин и групп), причем отобрать только те лекции, которые читаются в аудитории “B103”.--
SELECT CONCAT(t.Name,' ',t.Surname) as Teacher, s.Name as Subject, g.Name as Group_name
FROM Teachers t, Lectures l, Subjects s, GroupsLectures gl, Groups g
WHERE t.Id=l.TeacherId and l.SubjectId=s.Id and l.Id=gl.LectureId and gl.GroupId=g.Id and l.LectureRoom='B103';
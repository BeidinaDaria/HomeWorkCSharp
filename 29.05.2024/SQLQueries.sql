--1. ������� ��� ��������� ���� ����� �������������� � �����.--
SELECT Surname, t.Name, g.Name as Group_Name
FROM Teachers t, Groups g;

--2. ������� �������� �����������, ���� �������������� ������ ������� ��������� ���� �������������� ����������.--
SELECT f.Name
FROM Faculties f, Departments d
WHERE d.FacultyId=f.Id
GROUP BY f.Name,f.Financing
HAVING f.Financing<SUM(d.Financing);

--3. ������� ������� ��������� ����� � �������� �����, ������� ��� ��������.--
-- ��� ������� ����� ��������� ����� JOIN. � �� ��� � �������, �� ��������� �� join-� ��� �� �������...--
SELECT c.curator_surname as Surname, g.Name
FROM Curators c, Groups g, GroupsCurators gc
WHERE g.Id=gc.GroupId and gc.CuratorId=c.Id;

--4. ������� ����� � ������� ��������������, ������� ������ ������ � ������ �P107�.--
SELECT t.Name, t.Surname
FROM Teachers t, GroupsLectures gl, Groups g, Lectures l
WHERE t.Id=l.TeacherId and l.Id=gl.LectureId and gl.GroupId=g.Id and g.Name='P107';

--5. ������� ������� �������������� � �������� ����������� �� ������� ��� ������ ������.--
SELECT t.Surname, f.Name as Faculty
FROM Teachers t, Lectures l, GroupsLectures gl, Groups g, Departments d, Faculties f
WHERE t.Id=l.TeacherId and l.Id=gl.LectureId and gl.GroupId=g.Id and g.DepartmentId=d.Id and d.FacultyId=f.Id;

--6. ������� �������� ������ � �������� �����, ������� � ��� ���������.--
SELECT d.Name as Department, g.Name as Group_name
FROM Departments d, Groups g
WHERE d.Id=g.DepartmentId;

--7. ������� �������� ���������, ������� ������ ������������� �Samantha Adams�.--
SELECT s.Name
FROM Subjects s, Lectures l, Teachers t
WHERE t.Id=l.TeacherId and l.SubjectId=s.Id and CONCAT(t.Name,t.Surname)='Samantha Adams';

--8. ������� �������� ������, �� ������� �������� ���������� 'Database Theory'--
SELECT d.Name
FROM Subjects s, Lectures l, GroupsLectures gl, Groups g, Departments d
WHERE s.Id=l.SubjectId and l.Id=gl.LectureId and gl.GroupId=g.Id and g.DepartmentId=d.Id and s.Name='Database Theory';

--9. ������� �������� �����, ������� ��������� � ���������� �Computer Science�.--
SELECT g.Name
FROM Groups g, Departments d, Faculties f
WHERE d.Id=g.DepartmentId and d.FacultyId=f.Id and f.Name='Computer Science';

--10. ������� �������� ����� 5-�� �����, � ����� �������� �����������, � ������� ��� ���������.--
SELECT g.Name as Group_name, f.Name as Faculty
FROM Groups g, Departments d, Faculties f
WHERE d.Id=g.DepartmentId and d.FacultyId=f.Id and g.Year=5;

--11. ������� ������ ����� �������������� � ������, ������� ��� ������ (�������� ��������� � �����), ������ �������� ������ �� ������, ������� �������� � ��������� �B103�.--
SELECT CONCAT(t.Name,' ',t.Surname) as Teacher, s.Name as Subject, g.Name as Group_name
FROM Teachers t, Lectures l, Subjects s, GroupsLectures gl, Groups g
WHERE t.Id=l.TeacherId and l.SubjectId=s.Id and l.Id=gl.LectureId and gl.GroupId=g.Id and l.LectureRoom='B103';
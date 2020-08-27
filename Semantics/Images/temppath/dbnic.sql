

select a.examid, a.batchid, a.examtype, a.workingdays, b.detailsid, 
b.classid, b.sectionid, b.courseid, b.FullMarks, b.passmarks,
c.studentid, c.MarksTh, c.MarksPR, c.Attendance  from tbexammaster a
inner join tbexamdetails b on a.examid = b.examid
left join tbmarks c on b.detailsid = c.detailsid where a.examid = 24 and examtype = 10 and classid = 96 and sectionid = 17

select a.studentid, a.studentname, a.classid, a.classname, a.sectionid, a.section, b.courseid from vw_studentinfo a
inner join (
	select b.classid, b.sectionid, b.courseid, c.studentid  from tbexammaster a
	inner join tbexamdetails b on a.examid = b.examid
	left join tbmarks c on b.detailsid = c.detailsid where a.examid = 24 and examtype = 10 and classid = 96 and sectionid = 17
) b on a.classid = b.classid and a.sectionid = b.sectionid

--select a.examid, a.batchid, a.examtype, a.workingdays, b.detailsid, 
--b.classid, b.sectionid, b.courseid, b.FullMarks, b.passmarks,
--c.studentid, c.MarksTh, c.MarksPR, c.Attendance  from tbexammaster a
--inner join tbexamdetails b on a.examid = b.examid
--left join tbmarks c on b.detailsid = c.detailsid where studentid = 1854
--select * from tbmarks

-- select * from tbstudent where regnoprefix = '1473001'
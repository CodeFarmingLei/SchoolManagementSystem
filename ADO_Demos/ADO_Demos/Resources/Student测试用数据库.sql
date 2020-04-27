-- �½� student ѧ�����ݿ�
CREATE DATABASE student;
-- ��λ�������ݿ�
USE student;

SELECT * FROM system_users WHERE ucode='admin' AND upwd='123456' 

-- �½� system_users ��¼�˻���Ϣ��
CREATE TABLE system_users(
	uid INT IDENTITY PRIMARY KEY,					-- �˻�ID
	ucode VARCHAR(10) NOT NULL,					-- �˺�
	upwd VARCHAR(10) NOT NULL						-- �˻�����
)
-- ��Ӳ������ݵ� system_users ��¼�˻���Ϣ��
INSERT INTO system_users VALUES('101010','123456');
-- ��ѯ system_users ��¼�˻���Ϣ������
SELECT * FROM system_users
-- ��� system_users �༶��Ϣ������
TRUNCATE TABLE system_users;


-- �½� classInfo �༶��Ϣ��
CREATE TABLE classInfo(
	cid INT IDENTITY(1,1) PRIMARY KEY,				-- �༶ID
	cname NVARCHAR(20) NOT NULL 				-- �༶���
)
-- ��Ӳ������ݵ� classInfo �༶��Ϣ��
INSERT INTO classInfo VALUES('S201'),('S202'),('S203'),('S204'),('S205'),('S206'),('S207'),('S208');
-- ��ѯ classInfo �༶������
SELECT * FROM classInfo
-- ��� classInfo �༶��Ϣ������
TRUNCATE TABLE classInfo;

SELECT * FROM classInfo WHERE cname ='S201'

-- �½� student ѧ����Ϣ��
CREATE TABLE student(
	sid INT IDENTITY(1000,1) PRIMARY KEY,				-- ѧ��ID
	sname VARCHAR(20) NOT NULL,							-- ѧ������
	ssex INT NOT NULL,												-- ѧ���Ա�
	sage INT NOT NULL,												-- ѧ������
	sbirthday DATE NOT NULL,									-- ѧ������
	sphone VARCHAR(20) NOT NULL,							-- ѧ���绰
	saddress VARCHAR(50) NOT NULL,						-- ѧ����ַ
	scid INT NOT NULL,												-- ѧ���༶���
	spassword VARCHAR(6) NOT NULL,						-- ѧ����¼����
	foreign key (scid) references classInfo(cid),			-- �����༶���
)
-- ��Ӳ������ݵ� Student ѧ����Ϣ��
INSERT INTO student VALUES('Admin',1,DATEDIFF(YY, '1990-01-01', GETDATE()),'1990-01-01','13888888888','���ϳ�ɳ',1,'123456');
INSERT INTO student VALUES('����ȫ',1,DATEDIFF(YY, '1990-01-01', GETDATE()),'1990-01-01','13812345678','���ϳ�ɳ',1,'456789');
INSERT INTO student VALUES('���',1,DATEDIFF(YY, '1991-02-02', GETDATE()),'1991-02-02','15041576258','�����˲�',2,'789123');
INSERT INTO student VALUES('�ڼ�ǫ',1,DATEDIFF(YY, '1992-03-03', GETDATE()),'1992-03-03','13945624865','������ˮ',4,'147258');
INSERT INTO student VALUES('������',1,DATEDIFF(YY, '1993-04-04', GETDATE()),'1993-04-04','15842548964','ɽ������',1,'258369');
INSERT INTO student VALUES('�ܽ���',1,DATEDIFF(YY, '1995-06-07', GETDATE()),'1995-06-07','17654254892','̨������',4,'369147');
INSERT INTO student VALUES('��С��',0,DATEDIFF(YY, '1996-03-22', GETDATE()),'1996-03-22','13545568785','�������',3,'111222');
INSERT INTO student VALUES('������',0,DATEDIFF(YY, '1994-02-01', GETDATE()),'1994-02-01','13042148961','�������',3,'333444');
INSERT INTO student VALUES('������',0,DATEDIFF(YY, '1997-05-12', GETDATE()),'1997-05-12','13848754865','����˳��',2,'555666');
INSERT INTO student VALUES('ìʮ��',1,DATEDIFF(YY, '1998-06-07', GETDATE()),'1998-06-07','16514567869','�Ĵ�����',4,'777888');
INSERT INTO student VALUES('���ֹ�',1,DATEDIFF(YY, '1999-02-04', GETDATE()),'1999-02-04','17532448546','��������',2,'999000');
INSERT INTO student VALUES('˾����',1,DATEDIFF(YY, '1997-04-06', GETDATE()),'1997-04-06','13545678924','�½���ʲ',1,'112233');
INSERT INTO student VALUES('�����',1,DATEDIFF(YY, '1999-04-06', GETDATE()),'1999-04-06','13545645924','�㽭����',6,'445566');
INSERT INTO student VALUES('��ǿ',1,DATEDIFF(YY, '1993-08-21', GETDATE()),'1993-08-21','13645646215','���ϴ���',5,'778899');
INSERT INTO student VALUES('��С��',1,DATEDIFF(YY, '1996-02-23', GETDATE()),'1996-02-23','13701257945','����������',7,'123123');
INSERT INTO student VALUES('���',1,DATEDIFF(YY, '1998-09-16', GETDATE()),'1998-09-16','15846532452','�㽭����',3,'456456');
-- ��ѯ student ѧ����Ϣ������
SELECT * FROM student AS S
LEFT JOIN classInfo AS C ON C.cid = S.scid
-- ��� student ѧ����Ϣ������
TRUNCATE TABLE student;


-- �½� student_backup ѧ��������Ϣ��
CREATE TABLE student_backup(
	sid INT IDENTITY(1000,1) PRIMARY KEY,				-- ѧ��ID
	sname VARCHAR(20) NOT NULL,							-- ѧ������
	ssex INT NOT NULL,												-- ѧ���Ա�
	sage INT NOT NULL,												-- ѧ������
	sbirthday DATE NOT NULL,									-- ѧ������
	sphone VARCHAR(20) NOT NULL,							-- ѧ���绰
	saddress VARCHAR(50) NOT NULL,						-- ѧ����ַ
	scid INT NOT NULL,												-- ѧ���༶���
	spassword VARCHAR(6) NOT NULL,						-- ѧ����¼����
	foreign key (scid) references classInfo(cid),			-- �����༶���
)
-- ��ѯ student_backup ���ݱ�����
SELECT * FROM student_backup AS S
LEFT JOIN classInfo AS C ON C.cid = S.cid
-- ��� student_backup ѧ����Ϣ���ݱ�����
TRUNCATE TABLE student_backup;


-- �½� teacher ��ʦ��Ϣ��
CREATE TABLE teacher(
	tid INT IDENTITY PRIMARY KEY,								-- ��ʦID
	tcid INT NOT NULL,												-- ���ұ��
	tname VARCHAR(20) NOT NULL,							-- ��ʦ����
	tProfession CHAR(1) NOT NULL,							-- �γ�רҵ (רҵ��1:����,2:�����,3:��ѧ,4:��ѧ)
	tpassword CHAR(6) NOT NULL								-- ��¼����
	foreign key (tcid) references classInfo(cid),			-- �����༶���
)
-- ��Ӳ������ݵ� teacher ��ʦ��Ϣ��
INSERT INTO teacher VALUES(1,'����',3,'123456'),(2,'���',1,'456789'),(3,'����',2,'789123');
-- ��ѯ teacher ѧ����Ϣ������
SELECT * FROM teacher
-- ��� teacher ѧ����Ϣ������
TRUNCATE TABLE teacher;

SELECT C.cname,T.tname,T.tProfession,T.tpassword FROM teacher AS T
LEFT JOIN classInfo AS C ON T.tcid = C.cid
WHERE tid=1;

-- �½� Course �γ���Ϣ��
CREATE TABLE course(
	cid INT IDENTITY PRIMARY KEY,					-- �γ����
	ctid INT NOT NULL,										-- ��ʦ���
	cname NVARCHAR(20) NOT NULL,				-- �γ�����
	climit INT NOT NULL										-- ѡ������
)
-- ��Ӳ������ݵ� Course �γ���Ϣ��
INSERT INTO Course VALUES(1,'��ά������Ӧ��',0),(2,'��������',0),(3,'Android�������',0);
-- ��ѯ Course �γ���Ϣ������
SELECT * FROM Course
-- ��� Course �γ���Ϣ������
TRUNCATE TABLE Course;


-- �½� SC_Mapping �ɼ���
CREATE TABLE SC_Mapping(
	scid INT IDENTITY PRIMARY KEY,								-- ���
	sid INT NOT NULL,													-- ѧ�����
	cid INT NOT NULL,													-- �γ̱��
	score INT NOT NULL													-- ����
	foreign key (scid) references course(cid),					-- �����γ̱����
	foreign key (cid) references course(cid)						-- �����γ̱����
)
-- ��Ӳ������ݵ� SC_Mapping �ɼ���
INSERT INTO SC_Mapping VALUES(1000,1,80),(1000,2,90),(1000,3,100);
-- ��ѯ SC_Mapping �ɼ�������
SELECT * FROM SC_Mapping
-- ��� SC_Mapping �ɼ�������
TRUNCATE TABLE SC_Mapping;

SELECT SC.scid,S.sname,C.cname,SC.score FROM SC_Mapping AS SC
LEFT JOIN student AS S ON SC.sid = S.sid
LEFT JOIN course AS C ON SC.cid = C.cid
WHERE SC.sid = 1000

-----------------------------------------------------------------------------------------------------

-- ɾ����(���Դ�����Ч��)
DELETE FROM student WHERE sid=1015

-- ����Student�������Ա�˺������������
UPDATE student SET sbirthday=DATEADD(YY,1,sbirthday) WHERE sid=1000;

-- ���Student����������
TRUNCATE TABLE student;

-- ���Student���ݱ�������
TRUNCATE TABLE student_backup;

-- Լ�������������ڵ�Student����Ϣ
-- WHERE DATEDIFF(DD,sbirthday,GETDATE())=3

-- ����ʽ�����յ�������
-- ORDER BY sbirthday DESC;

-- �߼���ѯ����ѯStudent����ȫ����Ϣ(�Ա���ֵת���ɺ��֣������ַ����ָ���Ϊ�����գ����ս������У��ж����������)
SELECT
	S.sid AS 'ѧ��ID',
	S.sname AS 'ѧ������',
	(
		CASE S.ssex
		WHEN'1' THEN'��'
		WHEN'0' THEN'Ů'
		ELSE '������'
		END
	) AS 'ѧ���Ա�',
	S.sage AS 'ѧ������',
	(
		CAST(YEAR(S.sbirthday) AS CHAR(4)) +'��'+
		CAST(MONTH(S.sbirthday) AS VARCHAR(2)) +'��'+
		CAST(DAY(S.sbirthday) AS VARCHAR(2)) +'��'
	) AS 'ѧ������',
	S.sphone AS 'ѧ���绰',
	S.saddress AS 'ѧ����ַ',
	C.cname AS 'ѧ���༶',
	S.spassword AS 'ѧ����¼����',
	(
		CASE
		WHEN S.sage<=18 THEN'δ����'
		WHEN S.sage BETWEEN 18 AND 30 THEN'����'
		WHEN S.sage BETWEEN 30 AND 60 THEN'����'
		WHEN S.sage>60 THEN'����'
		END
	) AS '���������'
FROM student AS S
LEFT JOIN classInfo AS C ON C.cid = S.scid



SELECT * FROM student WHERE sid=1015
UPDATE student set sname='',sage=20 WHERE sid=1000;

SELECT S.sid,S.sname,S.ssex,S.sage,S.sbirthday,S.sphone,S.saddress,C.cname FROM student AS S LEFT JOIN classInfo AS C ON C.cid = S.cid

SELECT S.sid,S.sname,S.ssex,S.sage,S.sbirthday,S.sphone,S.saddress,C.cname,S.spassword FROM student AS S LEFT JOIN classInfo AS C ON C.cid = S.scid WHERE sid=1000
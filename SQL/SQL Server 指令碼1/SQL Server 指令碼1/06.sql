--�X�ָ��
--inner join 
select c.�Ǹ�,a.�m�W,co.�ҵ{�s��
--�Z��.* ->�Z�Ÿ̭����ǥ͸��
--�i�H�ΧO�W���N �ܦ� c.*
from �Z�� as c 
inner join �ǥ� as a on c.�Ǹ� = a.�Ǹ� --�~����s��
inner join �ҵ{ as co on co.�ҵ{�s��= co.�ҵ{�s�� --�~����s��


-------------------------------------------------------
--inner join ���ĤG�ؼg�k

select s.�Ǹ�,s.�m�W, s.�ʧO,co.�ҵ{�s��,co.�W��,co.�Ǥ�,
e.�m�W,p.��t,c.�Ы�,c.�W�Үɶ�
from ���u as e 
inner join (�б� as p inner join 
(�ҵ{ as co inner join 
(�Z�� as c inner join �ǥ� as s on c.�Ǹ�=s.�Ǹ�) 
on c.�ҵ{�s��=co.�ҵ{�s��) 
on p.�б½s��=c.�б½s��) 
on e.�����Ҧr��=p.�����Ҧr��
---------------------------------------
--�ĤT�ؼg�k(�۵M(���t)�X�֪k)

select s.�Ǹ�,s.�m�W, s.�ʧO,co.�ҵ{�s��,co.�W��,co.�Ǥ�,
e.�m�W,p.��t,c.�Ы�,c.�W�Үɶ�
from �Z�� as c ,�ǥ� as s, �ҵ{ as  co,�б� as p,���u as e 
where  c.�Ǹ�=s.�Ǹ� and c.�ҵ{�s��=co.�ҵ{�s�� 
and c.�б½s��=p.�б½s�� and e.�����Ҧr��=p.�����Ҧr��
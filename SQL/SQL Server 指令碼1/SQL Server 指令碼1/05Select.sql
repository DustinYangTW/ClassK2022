







select �ʧO,count(*) as �ǥͤH��
from �ǥ�
group by �ʧO

select �Ǹ�,count(*) as ��Ҽ�
from �Z��
group by �Ǹ�

select �б½s��,count(*) as �Ѯv�Q���
from �Z��
group by �б½s��

select �б½s��,�ҵ{�s��,count(*) as �Ѯv�Q���
from �Z��
group by �б½s��,�ҵ{�s��


--having(��where�\��@��)
select �Ǹ�,Count(*) as ��Ҽ�
from �Z��
--where COUNT(*) <3
group by �Ǹ�
having Count(*) <3
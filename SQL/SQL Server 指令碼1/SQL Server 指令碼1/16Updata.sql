update �ҵ{2
set �Ǥ� = 2 
where �ҵ{�s�� = 'CS222'

--�Y��ҤH��>=3�A�N�ҵ{�Ǥ��Ƨאּ30
update �ҵ{2
set �Ǥ� = 30 
where �ҵ{�s�� in (
select �ҵ{�s��
from �Z��
group by �ҵ{�s��
having COUNT(*)>=3
)

select �ҵ{�s��,COUNT(*)
from �Z��
group by �ҵ{�s��
having COUNT(*)>=3


--�⦳�Q��Ҫ��ҵ{,�N�ҵ{�Ǥ��Ƨאּ100
update �ҵ{2
set �Ǥ�=100
from �Z�� as c inner join �ҵ{2 as co
on c.�ҵ{�s��=co.�ҵ{�s��

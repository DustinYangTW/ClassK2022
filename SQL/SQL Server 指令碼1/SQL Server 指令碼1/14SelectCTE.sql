--CTE

with test
as(
select p.* from  �б� as p inner join ���u as e 
on p.�����Ҧr�� = e.�����Ҧr��
)

select * from test

with �D�޶��h
as(
select �m�W,1 as �h��,���u�r�� from �D�� where �D�ަr�� is null
union all --���p���A���Ʊư���
select �D��.�m�W,�h��+1 as �h��,�D��.���u�r�� from �D�� inner join �D�޶��h
on �D��.�D�ަr�� =  �D�޶��h.���u�r��
)
select �D�޶��h.�m�W,�D�޶��h.�h��
from �D�޶��h
order by �D�޶��h.�h��
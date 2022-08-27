function create() {
    $('#form').empty();
    var form = `<form action="/OthersSet/Create?idNmae=${idNmae}" method="post">
                           <input id="toDBName" type="toDBName" name="toDBName"/>
                           <button class="btn  btn-warning rounded-3 shadow mb-2 ms-2" type="submit">新增</button>
                        </form>`
    $('#form').append(form);
    $('#form').append(`<a class="btn btn-blue-n rounded-3 shadow mb-2 ms-2" onclick="reset()">返回</a>`);
}

function reset() {
    $('#form').empty();
    var form = `<a class="btn btn-blue-n rounded-3 shadow mb-2 ms-2" id="Create" onclick="create()">新增</a>`
    $('#form').append(form);
}

function chageformEdit(evt) {
    var id = evt.target.id;
    var Edit_id = `Edit_${id}`;
    var Create_id = `Create_${id}`;
    var Create_id_text = $(`#${Create_id}`).text().replace(/\s*/g, "");
    console.log(Create_id_text);
    $(`#${Create_id}`).empty();
    $(`#${Edit_id}`).empty();
    console.log(Edit_id);
    var form = `<form action="/OthersSet/Edit?idNmae=${idNmae}" method="post">
                            <input id="id" type="hidden" name="id" value="${id}"/>
                              <div class="d-flex justify-content-around align-items-center">
                                 <div class="col-9">
                                     <input id="toDBNameEdit" type="text" name="toDBNameEdit" value="${Create_id_text}" class="form-control form-control-lg"/>
                                 </div>
                                 <div>
                                     <button class="btn  btn-danger" type="submit">修改</button>
                                 </div>
                              </div>
                         </form>`
    $(`#${Create_id}`).append(form);
    $(`#${Edit_id}`).append(`<button type="button" class="btn btn-warning" onclick="resetEdit(event)" id="${id}">取消</button>`);
}
function resetEdit(evt) {
    var id = evt.target.id;
    var Edit_id = `Edit_${id}`;
    var Create_id = `Create_${id}`;
    var Create_id_text = $(`#toDBNameEdit`).val().replace(/\s*/g, "");

    $(`#${Create_id}`).empty();
    $(`#${Create_id}`).append(Create_id_text);
    $(`#${Edit_id}`).empty();
    $(`#${Edit_id}`).append(`<button type="button" class="btn btn-outline-primary" id="${id}" onclick="chageformEdit(event)">修改</button>`);
}

    function mainIdex() {
        var selectCountyValue = $(selectCounty).val();
    console.log(selectCountyValue);
    $('#selectCity').empty();
    var cityadd = `<option disabled style="display: none" selected value>請選擇</option>`;
    $('#selectCity').append(cityadd);
    $.ajax({
        url: `https://api.nlsc.gov.tw/other/ListTown1/${selectCountyValue}`,
    type: 'GET',
    timeout: 1000,
    success: function (data) {
                //console.log(data)
                for (i = 0; i < $(data).find("townname").length; i++) {
                    var cityid = data.getElementsByTagName("townname")[i].firstChild.nodeValue;
    console.log(cityid);
    var cityadd = `<option value="${cityid}">${cityid}</option>`;
    $('#selectCity').append(cityadd);
                }
            }
        });
    }

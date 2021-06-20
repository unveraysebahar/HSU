$(document).ready(function () {

    /* DataTables start here. */

    $('#animalSpeciesTable').DataTable({
        dom:
            "<'row'<'col-sm-3'l><'col-sm-6 text-center'B><'col-sm-3'f>>" +
            "<'row'<'col-sm-12'tr>>" +
            "<'row'<'col-sm-5'i><'col-sm-7'p>>",
        "order": [[6, "desc"]],
        buttons: [
            {
                text: 'Ekle',
                attr: {
                    id: "btnAdd",
                },
                className: 'btn btn-success',
                action: function (e, dt, node, config) {
                }
            },
            {
                text: 'Yenile',
                className: 'btn btn-warning',
                action: function (e, dt, node, config) {
                    $.ajax({
                        type: 'GET',
                        url: '/Admin/AnimalSpecies/GetAllAnimalSpecies/',
                        contentType: "application/json",
                        beforeSend: function () {
                            $('#animalSpeciesTable').hide();
                            $('.spinner-border').show();
                        },
                        success: function (data) {
                            const animalSpeciesListDto = jQuery.parseJSON(data);
                            console.log(animalSpeciesListDto);
                            if (animalSpeciesListDto.ResultStatus === 0) {
                                let tableBody = "";
                                $.each(animalSpeciesListDto.AnimalSpecies.$values,
                                    function (index, animalSpecies) {
                                        tableBody += `
                                                <tr>
                                    <td>${animalSpecies.Id}</td>
                                    <td>${animalSpecies.Name}</td>
                                    <td>${animalSpecies.Description}</td>
                                    <td>${convertFirstLetterToUpperCase(animalSpecies.IsActive.toString())}</td>
                                    <td>${convertFirstLetterToUpperCase(animalSpecies.IsDeleted.toString())}</td>
                                    <td>${animalSpecies.Note}</td>
                                    <td>${convertToShortDate(animalSpecies.CreatedDate)}</td>
                                    <td>${animalSpecies.CreatedByName}</td>
                                    <td>${convertToShortDate(animalSpecies.ModifiedDate)}</td>
                                    <td>${animalSpecies.ModifiedByName}</td>
                                    <td>
                                <button class="btn btn-primary btn-sm btn-update" data-id="${animalSpecies.Id}"><span class="fas fa-edit"></span></button>
                                <button class="btn btn-danger btn-sm btn-delete" data-id="${animalSpecies.Id}"><span class="fas fa-minus-circle"></span></button>
                                    </td>
                                            </tr>`;
                                    });
                                $('#animalSpeciesTable > tbody').replaceWith(tableBody);
                                $('.spinner-border').hide();
                                $('#animalSpeciesTable').fadeIn(1400);
                            } else {
                                toastr.error(`${animalSpeciesListDto.Message}`, 'İşlem Başarısız!');
                            }
                        },
                        error: function (err) {
                            console.log(err);
                            $('.spinner-border').hide();
                            $('#animalSpeciesTable').fadeIn(1000);
                            toastr.error(`${err.responseText}`, 'Hata!');
                        }
                    });
                }
            }
        ],
        language: {
            "sDecimal": ",",
            "sEmptyTable": "Tabloda herhangi bir veri mevcut değil",
            "sInfo": "_TOTAL_ kayıttan _START_ - _END_ arasındaki kayıtlar gösteriliyor",
            "sInfoEmpty": "Kayıt yok",
            "sInfoFiltered": "(_MAX_ kayıt içerisinden bulunan)",
            "sInfoPostFix": "",
            "sInfoThousands": ".",
            "sLengthMenu": "Sayfada _MENU_ kayıt göster",
            "sLoadingRecords": "Yükleniyor...",
            "sProcessing": "İşleniyor...",
            "sSearch": "Ara:",
            "sZeroRecords": "Eşleşen kayıt bulunamadı",
            "oPaginate": {
                "sFirst": "İlk",
                "sLast": "Son",
                "sNext": "Sonraki",
                "sPrevious": "Önceki"
            },
            "oAria": {
                "sSortAscending": ": artan sütun sıralamasını aktifleştir",
                "sSortDescending": ": azalan sütun sıralamasını aktifleştir"
            },
            "select": {
                "rows": {
                    "_": "%d kayıt seçildi",
                    "0": "",
                    "1": "1 kayıt seçildi"
                }
            }
        }
    });

    /* DataTables end here */

    /* Ajax GET / Getting the _AnimalSpeciesAddPartial as Modal Form starts from here. */

    $(function () {
        const url = '/Admin/AnimalSpecies/Add/';
        const placeHolderDiv = $('#modalPlaceHolder');
        $('#btnAdd').click(function () {
            $.get(url).done(function (data) {
                placeHolderDiv.html(data);
                placeHolderDiv.find(".modal").modal('show');
            });
        });

        /* Ajax GET / Getting the _AnimalSpeciesAddPartial as Modal Form ends here. */

        /* Ajax POST / Posting the FormData as AnimalSpeciesAddDto starts from here. */

        placeHolderDiv.on('click',
            '#btnSave',
            function (event) {
                event.preventDefault();
                const form = $('#form-animalSpecies-add');
                const actionUrl = form.attr('action');
                const dataToSend = form.serialize();
                $.post(actionUrl, dataToSend).done(function (data) {
                    console.log(data);
                    const animalSpeciesAddAjaxModel = jQuery.parseJSON(data);
                    console.log(animalSpeciesAddAjaxModel);
                    const newFormBody = $('.modal-body', animalSpeciesAddAjaxModel.AnimalSpeciesAddPartial);
                    placeHolderDiv.find('.modal-body').replaceWith(newFormBody);
                    const isValid = newFormBody.find('[name="IsValid"]').val() === 'True';
                    if (isValid) {
                        placeHolderDiv.find('.modal').modal('hide');
                        const newTableRow = `
                                <tr name="${animalSpeciesAddAjaxModel.AnimalSpeciesDto.AnimalSpecies.Id}">
                                                    <td>${animalSpeciesAddAjaxModel.AnimalSpeciesDto.AnimalSpecies.Id}</td>
                                                    <td>${animalSpeciesAddAjaxModel.AnimalSpeciesDto.AnimalSpecies.Name}</td>
                                                    <td>${animalSpeciesAddAjaxModel.AnimalSpeciesDto.AnimalSpecies.Description}</td>
                                                    <td>${convertFirstLetterToUpperCase(animalSpeciesAddAjaxModel.AnimalSpeciesDto.AnimalSpecies.IsActive.toString())}</td>
                                                    <td>${convertFirstLetterToUpperCase(animalSpeciesAddAjaxModel.AnimalSpeciesDto.AnimalSpecies.IsDeleted.toString())}</td>
                                                    <td>${animalSpeciesAddAjaxModel.AnimalSpeciesDto.AnimalSpecies.Note}</td>
                                                    <td>${convertToShortDate(animalSpeciesAddAjaxModel.AnimalSpeciesDto.AnimalSpecies.CreatedDate)}</td>
                                                    <td>${animalSpeciesAddAjaxModel.AnimalSpeciesDto.AnimalSpecies.CreatedByName}</td>
                                                    <td>${convertToShortDate(animalSpeciesAddAjaxModel.AnimalSpeciesDto.AnimalSpecies.ModifiedDate)}</td>
                                                    <td>${animalSpeciesAddAjaxModel.AnimalSpeciesDto.AnimalSpecies.ModifiedByName}</td>
                                                    <td>
                                                        <button class="btn btn-primary btn-sm btn-update" data-id="${animalSpeciesAddAjaxModel.AnimalSpeciesDto.AnimalSpecies.Id}"><span class="fas fa-edit"></span></button>
                                                        <button class="btn btn-danger btn-sm btn-delete" data-id="${animalSpeciesAddAjaxModel.AnimalSpeciesDto.AnimalSpecies.Id}"><span class="fas fa-minus-circle"></span></button>
                                                    </td>
                                                </tr>`;
                        const newTableRowObject = $(newTableRow);
                        newTableRowObject.hide();
                        $('#animalSpeciesTable').append(newTableRowObject);
                        newTableRowObject.fadeIn(3500);
                        toastr.success(`${animalSpeciesAddAjaxModel.AnimalSpeciesDto.Message}`, 'Başarılı İşlem!');
                    } else {
                        let summaryText = "";
                        $('#validation-summary > ul > li').each(function () {
                            let text = $(this).text();
                            summaryText = `*${text}\n`;
                        });
                        toastr.warning(summaryText);
                    }
                });
            });
    });

    /* Ajax POST / Posting the FormData as AnimalSpeciesAddDto ends here. */

    /* Ajax POST / Deleting a AnimalSpecies starts from here */

    $(document).on('click',
        '.btn-delete',
        function (event) {
            event.preventDefault();
            const id = $(this).attr('data-id');
            const tableRow = $(`[name="${id}"]`);
            const animalSpeciesName = tableRow.find('td:eq(1)').text();
            Swal.fire({
                title: 'Silmek istediğinize emin misiniz?',
                text: `${animalSpeciesName} adlı kategori silinicektir!`,
                icon: 'warning',
                showCancelButton: true,
                confirmButtonColor: '#3085d6',
                cancelButtonColor: '#d33',
                confirmButtonText: 'Evet, silmek istiyorum.',
                cancelButtonText: 'Hayır, silmek istemiyorum.'
            }).then((result) => {
                if (result.isConfirmed) {
                    $.ajax({
                        type: 'POST',
                        dataType: 'json',
                        data: { animalSpeciesId: id },
                        url: '/Admin/AnimalSpecies/Delete/',
                        success: function (data) {
                            const animalSpeciesDto = jQuery.parseJSON(data);
                            if (animalSpeciesDto.ResultStatus === 0) {
                                Swal.fire(
                                    'Silindi!',
                                    `${animalSpeciesDto.AnimalSpecies.Name} adlı kategori başarıyla silinmiştir.`,
                                    'success'
                                );

                                tableRow.fadeOut(3500);
                            } else {
                                Swal.fire({
                                    icon: 'error',
                                    title: 'Başarısız İşlem!',
                                    text: `${animalSpeciesDto.Message}`,
                                });
                            }
                        },
                        error: function (err) {
                            console.log(err);
                            toastr.error(`${err.responseText}`, "Hata!")
                        }
                    });
                }
            });
        });
    $(function () {
        const url = '/Admin/AnimalSpecies/Update';
        const placeHolderDiv = $('#modalPlaceHolder');
        $(document).on('click', '.btn-update', function (event) {
            event.preventDefault();
            const id = $(this).attr('data-id');
            $.get(url, { animalSpeciesId: id }).done(function (data) {
                placeHolderDiv.html(data);
                placeHolderDiv.find('.modal').modal('show');
            }).fail(function () {
                toastr.error("Bir hata oluştu.");
            });
        });

    /* Ajax POST / Updating a AnimalSpecies starts from here */

        placeHolderDiv.on('click', '#btnUpdate', function (event) {
            event.preventDefault();

            const form = $('#form-animalSpecies-update');
            const actionUrl = form.attr('action');
            const dataToSend = form.serialize();
            $.post(actionUrl, dataToSend).done(function (data) {
                const animalSpeciesUpdateAjaxModel = jQuery.parseJSON(data);
                console.log(animalSpeciesUpdateAjaxModel);
                const newFormBody = $('.modal-body', animalSpeciesUpdateAjaxModel.AnimalSpeciesUpdatePartial);
                placeHolderDiv.find('.modal-body').replaceWith(newFormBody);
                const isValid = newFormBody.find('[name="IsValid"]').val() === 'True';
                if (isValid) {
                    placeHolderDiv.find('.modal').modal('hide');
                    const newTableRow = `
                                <tr name="${animalSpeciesUpdateAjaxModel.AnimalSpeciesDto.AnimalSpecies.Id}">
                                                    <td>${animalSpeciesUpdateAjaxModel.AnimalSpeciesDto.AnimalSpecies.Id}</td>
                                                    <td>${animalSpeciesUpdateAjaxModel.AnimalSpeciesDto.AnimalSpecies.Name}</td>
                                                    <td>${animalSpeciesUpdateAjaxModel.AnimalSpeciesDto.AnimalSpecies.Description}</td>
                                                    <td>${convertFirstLetterToUpperCase(animalSpeciesUpdateAjaxModel.AnimalSpeciesDto.AnimalSpecies.IsActive.toString())}</td>
                                                    <td>${convertFirstLetterToUpperCase(animalSpeciesUpdateAjaxModel.AnimalSpeciesDto.AnimalSpecies.IsDeleted.toString())}</td>
                                                    <td>${animalSpeciesUpdateAjaxModel.AnimalSpeciesDto.AnimalSpecies.Note}</td>
                                                    <td>${convertToShortDate(animalSpeciesUpdateAjaxModel.AnimalSpeciesDto.AnimalSpecies.CreatedDate)}</td>
                                                    <td>${animalSpeciesUpdateAjaxModel.AnimalSpeciesDto.AnimalSpecies.CreatedByName}</td>
                                                    <td>${convertToShortDate(animalSpeciesUpdateAjaxModel.AnimalSpeciesDto.AnimalSpecies.ModifiedDate)}</td>
                                                    <td>${animalSpeciesUpdateAjaxModel.AnimalSpeciesDto.AnimalSpecies.ModifiedByName}</td>
                                                    <td>
                                                        <button class="btn btn-primary btn-sm btn-update" data-id="${animalSpeciesUpdateAjaxModel.AnimalSpeciesDto.AnimalSpecies.Id}"><span class="fas fa-edit"></span></button>
                                                        <button class="btn btn-danger btn-sm btn-delete" data-id="${animalSpeciesUpdateAjaxModel.AnimalSpeciesDto.AnimalSpecies.Id}"><span class="fas fa-minus-circle"></span></button>
                                                    </td>
                                                </tr>`;
                    const newTableRowObject = $(newTableRow);
                    const animalSpeciesTableRow = $(`[name="${animalSpeciesUpdateAjaxModel.AnimalSpeciesDto.AnimalSpecies.Id}"]`);
                    newTableRowObject.hide();
                    animalSpeciesTableRow.replaceWith(newTableRowObject);
                    newTableRowObject.fadeIn(3500);
                    toastr.success(`${animalSpeciesUpdateAjaxModel.AnimalSpeciesDto.Message}`, "Başarılı İşlem!");
                }
                else {
                    let summaryText = "";
                    $('#validation-summary > ul > li').each(function () {
                        let text = $(this).text();
                        summaryText = `*${text}\n`;
                    });
                    toastr.warning(summaryText);
                }
            }).fail(function (response) {
                console.log(response);
            });
        });
    });
});
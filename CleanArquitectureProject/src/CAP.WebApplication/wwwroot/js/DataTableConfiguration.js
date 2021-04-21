window.onload = function () {
    $(function () {
        $("#dataTable").DataTable({
            "responsive": true,
            "autoWidth": false,
            "columnDefs": [
                { "orderable": false, "targets": 'nosort' }
            ],
            "order": [[0, "desc"]],
            "language": {
                "emptyTable": "Nenhum registro encontrado em nosso sistema",
                "lengthMenu": "Exibir _MENU_ registros por página",
                "search": "Pesquisar: ",
                "info": "Mostrando  _START_ - _END_ de um total de  _TOTAL_ registros",
                "infoEmpty": "Nenhum Registro",
                "paginate": {
                    "first": "Primeiro",
                    "last": "Último",
                    "next": "Próximo",
                    "previous": "Anterior"
                }
            }
        });
    });
};
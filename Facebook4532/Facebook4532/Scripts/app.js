var app = angular.module("app", []);
app.controller("Controlador1", function ($scope, $http) {
    $scope.Usuarios = [];
    $scope.usuarioactual = [];
    $scope.publicaciones = [];
    $scope.ListarUsuarios = function () {
        $http.post('Usuarios/Lista')
        .success(function (result) {
            $scope.Usuarios = result;
        }).error(function (data) {

        })
    };
    $scope.ListarUsuarios();
    $scope.traerUsuario = function (correo) {
        if (correo != null) {
            for (var i = 0; i < $scope.Usuarios.length; ++i) {
                if ($scope.Usuarios[i].Email == correo.Email) {
                    $scope.usuarioactual[0] = $scope.Usuarios[i];
                    var u = $scope.usuarioactual[0];
                    alert(u.Nombre);
                    $scope.mostrar();
                    $scope.ocultar();
                    $scope.mostrarlogout();
                    $scope.mostrarcol1();
                    $scope.mostrarAfter();
                    $scope.ListarPublicaciones();
                    $scope.mostrarlistapublicaciones();
                    console.log($scope.usuarioactual);
                }
            }
        }
    }

    $scope.ListarPublicaciones = function () {
        $http.post('Publicacions/ListaPublicaciones')
        .success(function (result) {
            $scope.publicaciones = result;
        }).error(function (data) {

        })
    };
    $scope.addUsuario = function (usuario) {
        $http.post('Usuarios/CrearU', { usuario: usuario })
        .success(function (result) {
            $scope.ListarUsuarios();
        }).error(function (data) {
            alert("error al add");
        })
    }
    $scope.addPublicacion = function (publicacion) {
        var usuario = $scope.usuarioactual[0];
        $http.post('Publicacions/crearPublicacion', { usuario: usuario, publicacion: publicacion })
        .success(function (result) {
            $scope.ListarPublicaciones();
        }).error(function (data) {
            alert("no agrego publicacion");
        })
    }
    $scope.Megusta = function (publicacion) {
        $http.post('Publicacions/ModificarMg', { publicacion: publicacion })
        .success(function (result) {
            $scope.ListarPublicaciones();
        }).error(function (data) {
            alert("no modifico");
        })
    }
    $scope.cerrarsesion = function () {
        $scope.usuarioactual = null;
        $scope.mostrarlogin();
        $scope.ocultarlistapublicaciones();
        $scope.ocultarpublicaciones();
        $scope.ocultarlogout();
        $scope.ocultarcol1();
        $scope.ocultarAfter();
    }

    $scope.mostrar = function () {
        document.getElementById('publicaciones').style.display = 'block';
    }
    $scope.mostrarcol1 = function () {
        document.getElementById('col1').style.display = 'block';
    }
    $scope.mostrarlogout = function () {
        document.getElementById('logout').style.display = 'block';
    }
    $scope.mostrarlistapublicaciones = function () {
        document.getElementById('listapublicacion').style.display = 'block';
    }
    $scope.mostrarlogin = function () {
        document.getElementById('login').style.display = 'block';
    }
    $scope.ocultar = function () {
        document.getElementById('login').style.display = 'none';
    }
    $scope.ocultarcol1 = function () {
        document.getElementById('col1').style.display = 'none';
    }

    $scope.ocultarlogout = function () {
        document.getElementById('logout').style.display = 'none';
    }
    $scope.ocultarpublicaciones = function () {
        document.getElementById('publicaciones').style.display = 'none';
    }
    $scope.ocultarlistapublicaciones = function () {
        document.getElementById('listapublicacion').style.display = 'none';
    }
    $scope.mostrarAfter = function () {
        document.getElementById('afertlogin').style.display = 'block';
    }
    $scope.ocultarAfter = function () {
        document.getElementById('afertlogin').style.display = 'none';
    }
})
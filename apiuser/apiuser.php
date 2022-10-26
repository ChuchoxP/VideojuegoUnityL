<?php
include('conexion.php');

$user = $_POST['usuario'];
$email = $_POST['correo'];
$psw = hash("sha256", $_POST['contraseña']);

$sql = "SELECT usuario from usuarios where usuario= '$user'";
$result = $pdo->query($sql);

if($result->rowCount()>0){
    $data = array('done' => false, 'message' => "error nombre de usuario ya existe");
    Header('Content-Type: application/json');
    echo json_encode($data);
    exit();
}
else{
    $sql = "SELECT correo from usuarios where correo= '$email'";
    $result = $pdo->query($sql);
    if($result->rowCount()>0){
        $data = array('done' => false, 'message' => "error email ya existe");
        Header('Content-Type: application/json');
        echo json_encode($data);
        exit();
    }
    else{
        $sql = "INSERT INTO usuarios set usuario = '$user', correo = '$email', contraseña ='$psw'";
        $pdo->query($sql);
            $data = array('done' => true, 'message' => "Usuario creado");
            Header('Content-Type: application/json');
            echo json_encode($data);
            exit();
    }
}


?>
<?php

include('conexion.php');

$user = $_POST['usuario'];
$psw = hash("sha256", $_POST['contraseña']);

$sql = "SELECT usuario from usuarios where usuario= '$user' AND contraseña= '$psw'";
$result = $pdo ->query($sql);

if($result->rowCount() >0)
{
	$data = array('done' => true , 'message' => "Bienvenido $user");
	Header('Content-Type: application/json');
	echo json_encode($data);
	exit();
}

else
{ $data = array('done' => false , 'message' => "nombreo o contraseña incorrectos");
	Header('Content-Type: application/json');
	echo json_encode($data);
	exit();
}
	





?>
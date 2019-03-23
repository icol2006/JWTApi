<?php

//test_api.php

include('Api.php');

$api_object = new API();
$data="";

if($_GET["action"] == 'fetch_all')
{
 $data = $api_object->fetch_all();
}

if($_POST["action"] == 'insert')
{
    $data = $api_object->insert();
}

if($_GET["action"] == 'fetch_single')
{    
 $data = $api_object->fetch_single();

}

if($_POST["action"] == 'update')
{
    $data = $api_object->update();
}

if($_GET["action"] == 'delete')
{
 $data = $api_object->delete();
}

echo json_encode($data);

?>
<?php

//Api.php

class API
{
 private $connect = '';

 function __construct()
 {
  $this->database_connection();
 }

 function database_connection()
 {
  $this->connect = new PDO("mysql:host=localhost;dbname=db_Clientes", "root", "123456");
 }

 function fetch_all()
 {
  $query = "SELECT * FROM tb_persona ORDER BY id";
  $statement = $this->connect->prepare($query);
  if($statement->execute())
  {
   while($row = $statement->fetch(PDO::FETCH_ASSOC))
   {
    $data[] = $row;
   }
   return $data;
  }
 }

 function insert()
 {
  if(isset($_POST["nombre"]))
  {
      $nombre=$_POST["nombre"];
      $direccion=$_POST["direccion"];
      $email=$_POST["email"];
      $telefono=$_POST["telefono"];

   $form_data = array(
    ':nombre'  => $_POST["nombre"],
    ':direccion'  => $_POST["direccion"],
    ':email'  => $_POST["email"],
    ':telefono'  => $_POST["telefono"]
   );
   //$query = "INSERT INTO tbl_sample (nombre, direccion, email, telefono) VALUES(" .  $nombre . "," . $direccion . "," . $email . "," $telefono . ")";
   
   $query = "
   INSERT INTO tb_persona 
   (nombre, direccion, email, telefono) VALUES 
   (:nombre, :direccion, :email,:telefono)
   ";
   $statement = $this->connect->prepare($query);
   if($statement->execute($form_data))
   {
    $data[] = array(
     'success' => '1'
    );
   }
   else
   {
    $data[] = array(
     'success' => '0'
    );
   }
  }
  else
  {
   $data[] = array(
    'success' => '0'
   );
  }
  return $data;
 }


 function fetch_single()
 {
    $data; 

    if(isset($_GET["id"]))
    {
        $id=$_GET["id"];
        $query = "SELECT * FROM tb_persona WHERE id=".$id;
        $statement = $this->connect->prepare($query);
        if($statement->execute())
        {
            
         foreach($statement->fetchAll() as $row)
         {             
          $data['id'] = $row['id'];
          $data['nombre'] = $row['nombre'];
          $data['direccion'] = $row['direccion'];
          $data['email'] = $row['email'];
          $data['telefono'] = $row['telefono'];
         }

        }
    }

    return $data;
 }

 function update()
 {
  if(isset($_POST["nombre"]))
  {
   $form_data = array(
    ':nombre' => $_POST['nombre'],
    ':direccion' => $_POST['direccion'],
    ':email' => $_POST['email'],
    ':telefono' => $_POST['telefono'],
    ':id'   => $_POST['id']
   );
   $query = "
   UPDATE tb_persona 
   SET nombre = :nombre, direccion = :direccion,  email = :email, telefono = :telefono 
   WHERE id = :id";
  
   $statement = $this->connect->prepare($query);
   if($statement->execute($form_data))
   {
    $data[] = array(
     'success' => '1'
    );
   }
   else
   {
    $data[] = array(
     'success' => '00'
    );
   }
  }
  else
  {
   $data[] = array(
    'success' => '01'
   );
  }
  return $data;
 }


 function delete()
 {
        
        if(isset($_GET["id"]))
        {
            $id=$_GET["id"];
            $query = "DELETE FROM tb_persona WHERE id =". $id;
            $statement = $this->connect->prepare($query);
            if($statement->execute())
            {
             $data[] = array(
              'success' => '1'
             );
            }
            else
            {
             $data[] = array(
              'success' => '0'
             );
            }
        }
  return $data;
 }
}




?>
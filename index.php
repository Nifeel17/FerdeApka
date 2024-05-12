<?php
    class Uzytkownik{
        public $ID;
        public $login;
        public $haslo;
    }

    if(isset($_POST['login']) && isset($_POST['haslo'])){
        require_once "connect.php";
        $polaczenie=@new mysqli($host, $db_user, $db_password, $db_name);
        $login=$_POST['login'];
        $haslo=$_POST['haslo'];
        $sql="SELECT * FROM uzytkownicy WHERE login='$login' AND haslo='$haslo'";
        if($rezultat=@$polaczenie->query($sql))
        {
            $liczbauzytkowanikow=$rezultat->num_rows; 
            if($liczbauzytkowanikow>0)
            {
                $uzytkownik = new Uzytkownik();
                $wiersz=$rezultat->fetch_assoc();
                foreach ($wiersz as $key => $value) {
                    $uzytkownik->$key = $value;
                }
                $myJSON = json_encode($uzytkownik, JSON_NUMERIC_CHECK);
                echo $myJSON;
            }
        }
    }
?>
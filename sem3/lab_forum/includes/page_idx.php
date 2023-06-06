<?php
	function prevPage(){
		if ($_POST["page"] > 0){
			$newPage = $_POST["page"] - 1;
			header('Location: http://lab.local/index.php?page=' . $newPage);
		}
	}

	function nextPage(){
		#SQL проверка
		$newPage = $_POST["page"] + 1;
		header('Location: http://lab.local/index.php?page=' . $newPage);
	}
	
	if($_POST["btn"] == "prev"){
		prevPage();
	}else if ($_POST["btn"] == "next"){
		nextPage();
	}
?>


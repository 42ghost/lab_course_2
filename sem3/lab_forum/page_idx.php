<?php
	function prevPage(){
		if ($_POST["page"] > 0){
			$newPage = $_POST["page"] - 1;
			header('Location: http://lab.local/index.php?page=' . $newPage);
		}else
		{
			header('Location: http://lab.local/index.php?page=0');
		}
	}

	function nextPage(){
		if ($_POST["page"] + 1 < $_POST["max_page"])
		{
			$newPage = $_POST["page"] + 1;
			header('Location: http://lab.local/index.php?page=' . $newPage);
		}
		else
		{
			header('Location: http://lab.local/index.php?page=' . $_POST["page"]);
		}
	}
	
	if($_POST["btn"] == "prev"){
		prevPage();
	}else if ($_POST["btn"] == "next"){
		nextPage();
	}
?>


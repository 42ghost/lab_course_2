<!DOCTYPE>


<html>
	<head>
		<title> Main page </title>
		<link rel="stylesheet" href="/includes/styles.css">
	</head>
	
	<body>
		<?php
			if(!(isset($_GET["page"]))){
				header("Location: http://lab.local/index.php?page=0");
			}
		?>
		
		<?php include ("includes/db.php"); # notes_amnt, note_list ?>
		<!-- Add note -->
		<?php include ("forms/new_note.php");?>	

				
		<!--first 10 notes-->
		<table width="600">
			<h1 align="center">Notes</h1>
			
			<?php 
				$N = 10; $page_num = $_GET["page"];
				
				if ($notes_amnt % 10 && $page_num == round($notes_amnt / $N))
					$N = $notes_amnt % 10;
					
				for ($id = $N * $page_num; $id < $N * ($page_num + 1); $id++)
				{
					include ("includes/note.php");
					if ($id + 1 == $notes_amnt)
					{
						break;
					}
				}
			?>
			
		</table>

		
		<!--Переход между страницами-->
		<table>
			<tr>
			<td>
			<form action="page_idx.php" method="POST">
				<input type="hidden" name="page" value=<?php echo $page_num ?>>
				<button type="submit" class="button" name="btn" value="prev">prev</button>
			</form>
			</td>
			<td>
			<form action="page_idx.php" method="POST">
				<input type="hidden" name="page" value=<?php echo $page_num ?>>
				<input type="hidden" name="max_page" value=<?php echo round($notes_amnt / $N)?>>
				<button type="submit" class="button" name="btn" value="next">next</button>
			</form>
			</td>
			</tr>
		</table>
		
	</body>
</html>







<!--
<script>

	function fshow(id)
	{
		let show = document.getElementById("show"+id);
		show.removeAttribute("hidden");
		
		let hide = document.getElementById("hide"+id);
		hide.textContent = "Hide comments";
		
		hide.setAttribute("onClick", "fhide('"+id+"')");
	}
	
	function fhide(id)
	{
		let show = document.getElementById("show"+id);
		show.setAttribute("hidden", true);
		
		let hide = document.getElementById("hide"+id);
		hide.textContent = "Show comments";
		
		show.setAttribute("onClick", "fshow('"+id+"')");
	}

</script>-->



















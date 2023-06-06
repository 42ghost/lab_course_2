
<script> 
	function show(id){
		let comm = document.getElementById("comm"+id);
		if (comm.getAttribute("hidden")){
			comm.removeAttribute("hidden");
		}else{
			comm.setAttribute("hidden", true);
		}
	}
</script>

<tr> <td>
	<!--<?php print_r($note_list[$id])?>-->
	<h3> Note <?php print($id + 1) ?> </h3>
	<table width=520 border=0>
		<tr>
		<td class="note" bgcolor="#E6E6FA" width=400>
			<?php print($note_list[$id]["text"]) ?>
		</td>
		
		<td align=center>
			<form action="reactions.php" method="POST">
				<input type="hidden" name="id" value=<?php echo $note_list[$id]["id"] ?>>
				<input type="hidden" name="reaction" value="like">
				<input type="hidden" name="amount" value=<?php echo $note_list[$id]["likes"] ?>>
				<input type="hidden" name="page" value=<?php echo $_GET["page"] ?>>
				<button style="background-color: #F2F2F2" type="submit">&#128077; <?php echo $note_list[$id]["likes"]?></button>
			</form>
		</td>
		
		<td align=center>
			<form action="reactions.php" method="POST">
				<input type="hidden" name="id" value=<?php echo $note_list[$id]["id"] ?>>
				<input type="hidden" name="reaction" value="dislike">
				<input type="hidden" name="amount" value=<?php echo $note_list[$id]["dislikes"] ?>>
				<input type="hidden" name="page" value=<?php echo $_GET["page"] ?>>
				<button style="background-color: #F2F2F2" type="submit">&#128078; <?php echo $note_list[$id]["dislikes"]?></button>
			</form>
		</td>
			
		<td align=center>
			<form action="reactions.php" method="POST">
				<input type="hidden" name="id" value=<?php echo $note_list[$id]["id"] ?>>
				<input type="hidden" name="reaction" value="indifference">
				<input type="hidden" name="amount" value=<?php echo $note_list[$id]["indifference"] ?>>
				<input type="hidden" name="page" value=<?php echo $_GET["page"] ?>>
				<button style="background-color: #F2F2F2" type="submit">😑 <?php echo $note_list[$id]["indifference"]?></button>
			</form>
		</td>	
		
		</tr>

		<tr>
			<?php
			if ($note_list[$id]["picture"])
			{
				$source = "images/".$note_list[$id]["id"].".jpg";
				echo "<td align='center'><img style='width:150px;' src='$source' /> </td>";
			}
			?>
		</tr>
				
		<tr>
		<td>
			<button id=<?php echo $id ?> onclick="show(<?php echo $id ?>)">Show comments</button>
			<table id="comm<?php echo $id?>" hidden="True">
				<?php include "includes/comments.php" ?>
			</table>
		</td>
		</tr>
		
	</table>

</td> <tr>

<form action="addnote.php" method="POST"  enctype="multipart/form-data">
	<table>
		<thead>
		<tr>
			<td><h2>New note</h2></td>
		</tr>
		</thead>
		
		<tr>
			<td>
				<textarea rows="8" cols="60" name="note" maxlength=840></textarea>
			</td>
		</tr>
		
		<tr>
			<table>
			<tr>
				<td width="320">
				<input type="file" name="image" accept="image/jpg, image/jpeg">
				</td>
				<input type="hidden" name="id" value=<?php echo $notes_amnt+1 ?>>
				<td>
				<input type="submit" value="Add new note">
				</td>
			</tr>
			</table>
		</tr>
	</tabel>
</form>

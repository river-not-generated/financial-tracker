class_name SceneTransition extends Control


signal done

func fade(out := false, instant := false) -> void:
	var tween: Tween
	if not instant: tween = create_tween()
	
	var time := 0.0 if instant else 0.5
	show()
	if out:
		fade_out(tween, time)
	else:
		fade_in(tween, time)
	tween.tween_callback(hide)
	await tween.finished
	done.emit()


# Override These !
func fade_out(tween: Tween, time := 0.5) -> void:
	tween.tween_property(self, "position", self.position, time)

func fade_in(tween: Tween, time := 0.5) -> void:
	tween.tween_property(self, "position", self.position, time)

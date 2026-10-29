class_name SceneTransition extends Control


signal done

func fade(out := false, instant := false) -> void:
	var tween: Tween
	if not instant: tween = create_tween()
	
	var time_mult := 0.0 if instant else 1.0
	show()
	if out:
		fade_out(tween, time_mult)
	else:
		fade_in(tween, time_mult)
	tween.tween_callback(hide)
	await tween.finished
	done.emit()


# Override These !
@export var time := 0.5
func fade_out(tween: Tween, time_mult := 1.0) -> void:
	tween.tween_property(self, "position", self.position, time*time_mult)

func fade_in(tween: Tween, time_mult := 1.0) -> void:
	tween.tween_property(self, "position", self.position, time*time_mult)

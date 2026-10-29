extends Control

const TRANSITIONS: Array[PackedScene] = [
	preload("uid://rxy5203aucd5")
]


signal done
func fade(out := false, instant := false) -> void:
	var transition: SceneTransition = TRANSITIONS[randi_range(0, TRANSITIONS.size()-1)].instantiate()
	add_child(transition)
	transition.fade(out, instant)
	await transition.done
	done.emit()
	transition.queue_free()

extends Control

const TRANSITIONS: Array[PackedScene] = [
	preload("uid://rxy5203aucd5"),
	preload("uid://cgy5kaus70n07"),
]
var UNSERIOUS_TRANSITIONS: Array[PackedScene] = [
	preload("uid://djplfjx6s6kit"),
	preload("uid://b8wox0hta2e58"),
]

var transitions := TRANSITIONS

func _ready() -> void:
	UNSERIOUS_TRANSITIONS.append_array(TRANSITIONS)

func _process(_delta: float) -> void:
	if Input.is_action_just_pressed("swap_transitions"):
		if transitions == UNSERIOUS_TRANSITIONS:
			transitions = TRANSITIONS
		else:
			transitions = UNSERIOUS_TRANSITIONS


signal done
func fade(out := false, instant := false) -> void:
	var transition: SceneTransition = transitions[randi_range(0, transitions.size()-1)].instantiate()
	add_child(transition)
	transition.fade(out, instant)
	await transition.done
	done.emit()
	transition.queue_free()

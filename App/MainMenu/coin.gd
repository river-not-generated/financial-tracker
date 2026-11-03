extends MeshInstance3D


func _ready() -> void:
	rotation.z = randf_range(-PI, PI)

func _process(delta: float) -> void:
	rotation.z += delta * 2

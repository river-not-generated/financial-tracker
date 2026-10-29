extends SceneTransition


@onready var jarona: AnimatedSprite2D = $Jarona
@export var max_scale := 80.0

func _ready() -> void:
	#$Jarona.modulate.a = 0.0
	$Jarona.scale = Vector2(0.001, 0.001)


func fade_out(tween: Tween, time_mult := 1.0) -> void:
	jarona.modulate.a = 1.0
	jarona.scale = Vector2(max_scale, max_scale)
	
	tween.tween_property(jarona, "scale", Vector2(0.001, 0.001), time*time_mult).set_trans(Tween.TRANS_EXPO)
	#tween.parallel().tween_property(jarona, "modulate:a", 0.0, time*time_mult)

func fade_in(tween: Tween, time_mult := 1.0) -> void:
	#jarona.modulate.a = 0.0
	jarona.scale = Vector2(0.001, 0.001)
	
	tween.tween_property(jarona, "scale", Vector2(max_scale, max_scale), time*time_mult).set_trans(Tween.TRANS_EXPO)
	#tween.parallel().tween_property(jarona, "modulate:a", 1.0, time*time_mult)

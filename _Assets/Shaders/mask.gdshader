shader_type canvas_item;

uniform sampler2D mask;

void fragment() {
	vec4 mask_texture = texture(mask, UV);
	
	COLOR.a = mask_texture.r;
}
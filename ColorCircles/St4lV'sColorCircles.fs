/*{
	"DESCRIPTION": "Generating shader: color circles with adjustable speed & colors",
	"CREDIT": "St4lV",
	"ISFVSN": "2",
	"CATEGORIES": [
		"Example"
	],
	"INPUTS": [
		{
			"NAME": "speed",
			"TYPE": "float",
			"DEFAULT": 0.5,
			"MIN": 0.1,
			"MAX": 3.0
		},
		{
			"NAME": "color1",
			"TYPE": "color",
			"DEFAULT": [
				1.0,
				1.0,
				1.0,
				1.0
			]
		},
		{
			"NAME": "color2",
			"TYPE": "color",
			"DEFAULT": [
				0.0,
				0.0,
				0.0,
				1.0
			]
		},
		{
			"NAME": "color3",
			"TYPE": "color",
			"DEFAULT": [
				0.0,
				0.9,
				1.0,
				1.0
			]
		}
	],
	"PASSES": [
		{
			"TARGET":"bufferVariableNameA",
			"WIDTH": "$WIDTH/16.0",
			"HEIGHT": "$HEIGHT/16.0"
		},
		{
			"DESCRIPTION": "Render at full resolution"
		}
	]
	
}*/

#define PI 3.14

void main() {
    vec2 uv = gl_FragCoord.xy / RENDERSIZE.xy;
    vec2 center = vec2(0.5, 0.5);

    float aspectRatio = RENDERSIZE.x / RENDERSIZE.x;
    uv.x *= aspectRatio;

    float time = TIME * 2.0 - speed;
    float cycleDuration = 1.0 / speed; 
    float phase = mod(time, cycleDuration * 3.0);

    float maxScreenSize = min(RENDERSIZE.x, RENDERSIZE.y);
    float minRadius1 = 1.2 * maxScreenSize;
    float maxRadius1 = 1.4 * maxScreenSize;
    
    float minRadius2 = 1.0 * maxScreenSize;
    float maxRadius2 = 1.2 * maxScreenSize;
    
    float minRadius3 = 0.8 * maxScreenSize;
    float maxRadius3 = 1.0 * maxScreenSize;
    
    float minRadius4 = 0.6 * maxScreenSize;
    float maxRadius4 = 0.8 * maxScreenSize;
    
    float minRadius5 = 0.4 * maxScreenSize;
    float maxRadius5 = 0.6 * maxScreenSize;
    
    float minRadius6 = 0.2 * maxScreenSize;
    float maxRadius6 = 0.4 * maxScreenSize;
    
    float minRadius7 = 0.0 * maxScreenSize;
    float maxRadius7 = 0.2 * maxScreenSize;

    float radius1, radius2, radius3, radius4, radius5, radius6, radius7;
    vec4 currentColor1, currentColor2, currentColor3, currentColor4, currentColor5, currentColor6, currentColor7;

    if (phase < cycleDuration) {
        radius1 = minRadius1 + (maxRadius1 - minRadius1) * (phase / cycleDuration);
        currentColor1 = color1;
    } else if (phase < 2.0 * cycleDuration) {
        radius1 = minRadius1 + (maxRadius1 - minRadius1) * ((phase - cycleDuration) / cycleDuration);
        currentColor1 = color2;
    } else {
        radius1 = minRadius1 + (maxRadius1 - minRadius1) * ((phase - 2.0 * cycleDuration) / cycleDuration);
        currentColor1 = color3;
    }

    if (phase < cycleDuration) {
        radius2 = minRadius2 + (maxRadius2 - minRadius2) * (phase / cycleDuration);
        currentColor2 = color2;
    } else if (phase < 2.0 * cycleDuration) {
        radius2 = minRadius2 + (maxRadius2 - minRadius2) * ((phase - cycleDuration) / cycleDuration);
        currentColor2 = color3;
    } else {
        radius2 = minRadius2 + (maxRadius2 - minRadius2) * ((phase - 2.0 * cycleDuration) / cycleDuration);
        currentColor2 = color1;
    }
    
    if (phase < cycleDuration) {
        radius3 = minRadius3 + (maxRadius3 - minRadius3) * (phase / cycleDuration);
        currentColor3 = color3;
    } else if (phase < 2.0 * cycleDuration) {
        radius3 = minRadius3 + (maxRadius3 - minRadius3) * ((phase - cycleDuration) / cycleDuration);
        currentColor3 = color1;
    } else {
        radius3 = minRadius3 + (maxRadius3 - minRadius3) * ((phase - 2.0 * cycleDuration) / cycleDuration);
        currentColor3 = color2;
    }
    
    if (phase < cycleDuration) {
        radius4 = minRadius4 + (maxRadius4 - minRadius4) * (phase / cycleDuration);
        currentColor4 = color1;
    } else if (phase < 2.0 * cycleDuration) {
        radius4 = minRadius4 + (maxRadius4 - minRadius4) * ((phase - cycleDuration) / cycleDuration);
        currentColor4 = color2;
    } else {
        radius4 = minRadius4 + (maxRadius4 - minRadius4) * ((phase - 2.0 * cycleDuration) / cycleDuration);
        currentColor4 = color3;
    }

    if (phase < cycleDuration) {
        radius5 = minRadius5 + (maxRadius5 - minRadius5) * (phase / cycleDuration);
        currentColor5 = color2;
    } else if (phase < 2.0 * cycleDuration) {
        radius5 = minRadius5 + (maxRadius5 - minRadius5) * ((phase - cycleDuration) / cycleDuration);
        currentColor5 = color3;
    } else {
        radius5 = minRadius5 + (maxRadius5 - minRadius5) * ((phase - 2.0 * cycleDuration) / cycleDuration);
        currentColor5 = color1;
    }
    
    if (phase < cycleDuration) {
        radius6 = minRadius6 + (maxRadius6 - minRadius6) * (phase / cycleDuration);
        currentColor6 = color3;
    } else if (phase < 2.0 * cycleDuration) {
        radius6 = minRadius6 + (maxRadius6 - minRadius6) * ((phase - cycleDuration) / cycleDuration);
        currentColor6 = color1;
    } else {
        radius6 = minRadius6 + (maxRadius6 - minRadius6) * ((phase - 2.0 * cycleDuration) / cycleDuration);
        currentColor6 = color2;
    }
    
    if (phase < cycleDuration) {
        radius7 = minRadius7 + (maxRadius7 - minRadius7) * (phase / cycleDuration);
        currentColor7 = color1;
    } else if (phase < 2.0 * cycleDuration) {
        radius7 = minRadius7 + (maxRadius7 - minRadius7) * ((phase - cycleDuration) / cycleDuration);
        currentColor7 = color2;
    } else {
        radius7 = minRadius7 + (maxRadius7 - minRadius7) * ((phase - 2.0 * cycleDuration) / cycleDuration);
        currentColor7 = color3;
    }

    float dist = distance(uv * RENDERSIZE.xy, center * RENDERSIZE.xy);
    vec4 pixelColor = vec4(0.0, 0.0, 0.0, 1.0);

    if (dist < radius1) {
        pixelColor = currentColor1;
    }
    if (dist < radius2) {
        pixelColor = currentColor2;
    }
    if (dist < radius3) {
        pixelColor = currentColor3;
    }
    if (dist < radius4) {
        pixelColor = currentColor4;
    }
    if (dist < radius5) {
        pixelColor = currentColor5;
    }
    if (dist < radius6) {
        pixelColor = currentColor6;
    }
    if (dist < radius7) {
        pixelColor = currentColor7;
    }

    gl_FragColor = pixelColor;
}

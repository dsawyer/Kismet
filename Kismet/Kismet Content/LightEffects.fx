float4x4 MatrixTransform : register(vs, c0);
float2 cameraPosition;
float2 lightPositions[4];
float2 lightDirections[4];
float lightAttenuations[4];
float lightAngles[4];
float lightRadii[4];
float lightBrightness[4];
float3 lightColours[4];
float2 lightSpells[4];
int numLightSpells;
int numLights;
float3 ambientLight;
sampler TextureSampler : register(s0);

// The input for the pixel shader
struct PixelInput
{
    float4 Position : VPOS;
    float4 Color    : COLOR0;
	float2 TexCoord : TEXCOORD0;
};

// Vertex shader (dummy vertex shader needed to be able to make ps_3_0 work...
void SpriteVertexShader(inout float4 color    : COLOR0,
                        inout float2 texCoord : TEXCOORD0,
                        inout float4 position : SV_Position)
{
    position = mul(position, MatrixTransform);
}

// Pixel Shader
float4 PS(PixelInput input) : COLOR0
{
	float4 Colour = tex2D(TextureSampler, input.TexCoord);

	// The value that represents how much light is to be removed at most
	float4 light;
	float4 lightValue = float4(0,0,0,1);
	// Various needed variables for calculating the necessary lighting
	float2 distanceToLight;
	float distance;
	float darknessRatio;
	float2 currentLight;
	float angleBetweenLight;

	if (numLights > 0)
	{ light = float4(0, 0, 0, 0); }

	for (int i = 0; i < numLights; i+=1)
	{
		// Get the position of the light in screen coordinates
		currentLight = lightPositions[i] - cameraPosition;

		// Add the light's value for providing a 'mood' lighting
		light = float4(lightColours[i].x, lightColours[i].y, lightColours[i].z, 0) / numLights;
		
		// Get the distance between the point and the light
		distanceToLight = input.Position - currentLight;

		angleBetweenLight = dot(normalize(lightDirections[i]), normalize(distanceToLight));

		if (angleBetweenLight >= lightAngles[i])
		{
			distance = sqrt((distanceToLight.x * distanceToLight.x) + (distanceToLight.y * distanceToLight.y));
		
			// If the distance between the point and a light source is less than
			// the light source's radius, then the point is provided with some light
			if (distance <= lightRadii[i])
			{
				darknessRatio = ((lightRadii[i] - distance)/lightRadii[i]) * ((lightRadii[i] - distance)/lightRadii[i]);
				darknessRatio *= lightBrightness[i];
				darknessRatio *= lightAttenuations[i];

				if (angleBetweenLight >= 0)
				{ darknessRatio *= (angleBetweenLight * angleBetweenLight); }
				else if (angleBetweenLight < 0)
				{ darknessRatio *= (-1 * angleBetweenLight) * (-1 * angleBetweenLight); }
				lightValue += (darknessRatio) * light;
			}
		}
	}

	for (int i = 0; i < numLightSpells; i+=1)
	{
		distanceToLight = input.Position - (lightSpells[i] - cameraPosition);
		distance = sqrt((distanceToLight.x * distanceToLight.x) + (distanceToLight.y * distanceToLight.y));
		
		if (distance < 200)
		{
			darknessRatio = ((200 - distance)/200);
			lightValue += darknessRatio * float4(1,1,1,1);
		}
	}

	// Modify the colour based on the amount of light coming in
	Colour = Colour * float4(lightValue.rgb + ambientLight.rgb, 1);

	return Colour;
}

technique Shader
{
	pass P0
	{
		VertexShader = compile vs_3_0 SpriteVertexShader();
		PixelShader = compile ps_3_0 PS();
	}
}
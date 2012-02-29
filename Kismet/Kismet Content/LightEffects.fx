float4x4 MatrixTransform : register(vs, c0);
float2 cameraPosition;
float2 lightPositions[60];
float lightRadii[60];
float lightBrightness[60];
int numLights;
sampler TextureSampler : register(s0);

// Sampler for the incoming texture that
// allows manipulation of the texture
/*sampler2D TextureSampler = sampler_state
{
	Texture = (myTexture);
	minFilter = Linear;
	magFilter = Linear;
	AddressU = Clamp;
	AddressV = Clamp;
};*/

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
	float4 darkness = float4(0.5f, 0.5f,0.5f, 0);

	// Various needed variables for calculating the necessary lighting
	float2 distanceToLight;
	float distance;
	float lightRatio = 1.0f;
	float2 currentLight;

	for (int i = 0; i < numLights; i+=1)
	{
		// Get the position of the light in screen coordinates
		currentLight = lightPositions[i] - cameraPosition;

		// Get the distance between the point and the light
		distanceToLight = input.Position - currentLight;
		distance = sqrt((distanceToLight.x * distanceToLight.x) + (distanceToLight.y * distanceToLight.y));
		
		// If the distance between the point and a light source is less than
		// the light source's radius, then the point is provided with some light
		if (distance < lightRadii[i])
		{
			lightRatio -= (lightRadii[i]*1.2f - distance)/lightRadii[i];
		}
	}

	// Clamp the lighting ratio
	if (lightRatio > 1)
	{ lightRatio = 1; }
	else if (lightRatio < 0)
	{ lightRatio = 0; }

	// Modify the colour based on the amount of light coming in
	Colour = Colour - (lightRatio * darkness);

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
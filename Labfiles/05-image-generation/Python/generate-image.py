import requests
import base64
import os
from dotenv import load_dotenv
from datetime import datetime


def main():
    try:
        # Load environment variables
        load_dotenv()
        api_base = os.getenv("AZURE_OAI_ENDPOINT")
        api_key = os.getenv("AZURE_OAI_KEY")
        deployment = os.getenv("AZURE_OAI_DEPLOYMENT")  # e.g., gpt-image-1
        api_version = '2025-04-01-preview'

        # Ensure the endpoint ends without a trailing slash
        if api_base.endswith('/'):
            api_base = api_base[:-1]

        # Get prompt for image to be generated
        os.system('clear' if os.name == 'posix' else 'cls')
        prompt = input("Enter a prompt to request an image: ")

        # Construct the request URL
        url = f"{api_base}/openai/deployments/{deployment}/images/generations?api-version={api_version}"
        headers = {
            "api-key": api_key,
            "Content-Type": "application/json"
        }

        # gpt-image-1 supported parameters (confirmed from Microsoft docs):
        # - size:    "1024x1024", "1024x1536", "1536x1024"
        # - quality: "low", "medium", "high" (default: "high")
        # NOT supported: style, response_format (always returns b64_json automatically)
        body = {
            "prompt": prompt,
            "n": 1,
            "size": "1024x1024",
            "quality": "high"
        }

        print("Calling URL:", url)

        # Submit the image generation request (synchronous for gpt-image-1)
        response = requests.post(url, headers=headers, json=body)

        if response.status_code != 200:
            print("Failed to generate image.")
            print("Status Code:", response.status_code)
            print("Response:", response.text)
            return

        # Extract base64 image data
        response_data = response.json()
        image_b64 = response_data['data'][0]['b64_json']

        # Decode and save as a PNG file
        image_bytes = base64.b64decode(image_b64)
        timestamp = datetime.now().strftime("%Y%m%d_%H%M%S")
        filename = f"/home/odl_user/mslearn-openai/Labfiles/05-image-generation/Python/generated_image_{timestamp}.png"
        output_filename = f"/mslearn-openai/Labfiles/05-image-generation/Python/generated_image_{timestamp}.png"

        with open(filename, "wb") as f:
            f.write(image_bytes)

        print(f"\n Image saved successfully as: {output_filename}")
        print(f"   Open the file to view your generated image.")

    except Exception as ex:
        print("An error occurred:", ex)


if __name__ == '__main__':
    main()

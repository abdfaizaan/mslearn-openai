# Lab-04: Fine-Tuning [Read-Only]

### Estimated Duration: 30 Minutes

## Topics

  - [What is Fine Tuning?](#what-is-fine-tuning)
  - [When would you consider Fine Tuning vs Prompt Engineering?](#when-would-you-consider-fine-tuning-vs-prompt-engineering)
  - [Operation Cost Considerations](#operation-cost-considerations)


## What is Fine-Tuning?

Fine-tuning is the process of customizing an existing AI model for a specific task or domain by using additional data. OpenAI offers fine-tuning for its language models, such as GPT-3, which can generate natural language texts for various purposes.

Fine-tuning allows users to create customized models that can produce more accurate and relevant outputs than general models.

To fine-tune an OpenAI model, users need to prepare their own training and validation data, select a base model, and use the OpenAI CLI or Studio to start the fine-tuning job.

Fine-tuning can improve the performance and reduce the error rates of OpenAI models significantly.

---
## Fine-Tuning Training Data

Training data for fine-tuning OpenAI models is pairs of input prompts and desired outputs that reflect the specific task or domain you want to customize the model for. For example, if you want to fine-tune a model for generating product reviews, your training data could look like this:

```
{"prompt": "Review: I bought this laptop for my online classes, and it works great.", "completion": "Rating: 5 stars"}
{"prompt": "Review: The battery life is terrible and the screen is too small.", "completion": "Rating: 2 stars"}
{"prompt": "Review: This is a scam. The product never arrived, and the seller did not respond.", "completion": "Rating: 1 star"}
```

You can use the OpenAI CLI or Studio to prepare, validate, and format your training data into a JSON file that can be used for fine-tuning.

**IMPORTANT NOTE**:
It is important to note that to expect better results than using prompt engineering, you will need to have a large and high-quality dataset that is relevant to your task or domain, usually a few hundred high-quality examples.

---
## When would you consider Fine-Tuning vs Prompt Engineering?

Fine-tuning is a powerful tool that can be used to customize OpenAI models for specific tasks or domains. However, it is not always necessary to fine-tune a model to get the desired results.

Fine-tuning and prompt engineering are two methods of conditioning language models to perform specific tasks or domains.

Fine-tuning involves retraining an existing model on new data, while prompt engineering involves designing and testing input instructions that elicit the desired output from a model.

### Fine-Tuning

You might consider fine-tuning when you have a large and high-quality dataset that is relevant to your task or domain, and you want to create a customized model that can produce more accurate and consistent outputs than the general model.

### Prompt Engineering

You might consider prompt engineering when you have a limited or no dataset, and you want to leverage the existing knowledge and capabilities of a general model by asking the right questions or providing the right context.

**IMPORTANT NOTE**: Both methods require some trial and error, but fine-tuning usually takes more time and resources than prompt engineering, and it is not always necessary to fine-tune a model to get the desired results. It is therefore preferable to start with prompt engineering and only consider fine-tuning if you are unable to get the desired results.

---

### Operation Cost Considerations

Prompt engineering could be less cost-effective if you need to provide a large number of instructions to accomplish something similar to what you would get with a Fine-Tuned model, as you'd consume tokens with every request sent.

Hosting a Fine-Tune model also has its cost, but on medium to high volumes, that cost would be mostly irrelevant, so operational cost efficiency could be a driver for Fine-Tuning.

---

### Summary
In this lab, we learned that fine-tuning helps make AI models work better for specific tasks by training them with your own data, while prompt engineering is about giving clear and smart instructions to get the results you want. It’s better to begin with prompt engineering and go for fine-tuning only if you need more accurate and customised outputs.

---
### References

[OpenAI Fine Tuning](https://platform.openai.com/docs/guides/fine-tuning)

[Fine Tuning in the Azure OpenAI Service](https://learn.microsoft.com/en-us/azure/cognitive-services/openai/how-to/fine-tuning?pivots=programming-language-studio)

## You have successfully completed the lab.

By completing this **Build Prompt Engineering with Azure OpenAI Service** hands-on Lab, you have gained a strong foundation in working with **Azure OpenAI Service** and building generative AI solutions effectively:

  - You started with the **fundamentals of prompt engineering**, learning how to frame effective prompts, explore model parameters, and use system messages to guide behavior.
  - You progressed to **integrating Azure OpenAI into real-world applications** using SDKs, managing deployment endpoints, and exploring how generative AI can enhance app functionality—such as recommending hiking destinations.
  - You then deepened your knowledge through **advanced prompting techniques** like zero-shot, one-shot, and few-shot learning, as well as understanding the importance of context windows and token usage in generating high-quality outputs.
  - Finally, you explored the **concept of fine-tuning models**, understanding when to use it versus prompt engineering, how to prepare training data, and the cost and performance implications of each approach.


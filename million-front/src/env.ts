import z from "zod";

const envSchema = z.object({
  NEXT_PUBLIC_API_URL: z.url(),
})

export const env = envSchema.safeParse({
  NEXT_PUBLIC_API_URL: process.env.NEXT_PUBLIC_API_URL,
});
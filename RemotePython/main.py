import asyncio

from temporalio import activity
from temporalio.client import Client
from temporalio.worker import Worker


@activity.defn
async def remote_activity_3(input_str: str) -> str:
    return  f"Python Remote Activity Says. {input_str}"

async def main() -> None:
    client: Client = await Client.connect("localhost:7233", namespace="default")
    # Run the worker

    worker: Worker = Worker(
        client,
        task_queue="REMOTE_QUEUE_3",
        activities=[remote_activity_3],
    )
    await worker.run()

if __name__ == "__main__":
    asyncio.run(main())
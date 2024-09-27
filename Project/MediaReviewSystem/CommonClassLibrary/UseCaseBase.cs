namespace CommonClassLibrary
{
    public abstract class UseCaseBase<R>
    {

        //execute
        //presenter callback

        public ICallback<R> PresenterCallback { get; set; }

        public abstract void Action();

        public void Execute()
        {
            //Task.Run(() =>
            // {
            //     Action();
            // });
            Action();
        }

        public UseCaseBase(ICallback<R> callback)
        {
            PresenterCallback = callback;
        }
    }

}

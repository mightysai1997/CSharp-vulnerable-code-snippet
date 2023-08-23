public static unsafe int? InjectAndRunX86ASM(this Func<int> del, byte[] asm)
{
    if (del != null)
    {
        fixed (byte* ptr = &asm[0])
        {
            FieldInfo _methodPtr = typeof(Delegate).GetField("_methodPtr", BindingFlags.NonPublic | BindingFlags.Instance);
            FieldInfo _methodPtrAux = typeof(Delegate).GetField("_methodPtrAux", BindingFlags.NonPublic | BindingFlags.Instance);

            _methodPtr.SetValue(del, ptr);
            _methodPtrAux.SetValue(del, ptr);

            return del();
        }
    }
    else
    {
        return null;
    }
}

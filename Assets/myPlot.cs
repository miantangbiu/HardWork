using UnityEngine;
using System.Collections;

public static class myPlot
{
    public static void plotShow1()
    {
        plotManager.Instance.AddCommand(new plotStart());
        plotManager.Instance.AddCommand(new plotDialog("", "1", "一个普通的早晨！", 0));
        plotManager.Instance.AddCommand(new plotDialog("", "1", "但是我怎么变小了", 0));
        plotManager.Instance.AddCommand(new plotDialog("", "1", "哇哇哇啊啊啊", 0));
        plotManager.Instance.AddCommand(new plotDialog("", "1", "快九点了上班要迟到了", 0));
        plotManager.Instance.AddCommand(new plotDialog("", "1", "还要去上班啊", 0));
        plotManager.Instance.AddCommand(new plotEnd());

    }
    public static void plotShow2()
    {
        plotManager.Instance.AddCommand(new plotStart());
        plotManager.Instance.AddCommand(new plotDialog("", "1", "！！！！", 0));
        plotManager.Instance.AddCommand(new plotEnd());

    }
    public static void plotShow3()
    {

        plotManager.Instance.AddCommand(new plotStart());
        plotManager.Instance.AddCommand(new plotDialog("", "1", "是谁在我的地盘撒野!", 1));
        plotManager.Instance.AddCommand(new plotDialog("", "1", "哦吼，这不是房东大人吗", 1));
        plotManager.Instance.AddCommand(new plotDialog("", "1", "你怎么变得这么小了", 1));
        plotManager.Instance.AddCommand(new plotDialog("", "1", "哈哈哈哈哈哈", 1));
        plotManager.Instance.AddCommand(new plotDialog("", "1", "那我就大发慈悲收你做小弟吧", 1));
        plotManager.Instance.AddCommand(new plotEnd());

    }
    public static void plotShow4()
    {

        plotManager.Instance.AddCommand(new plotStart());
        plotManager.Instance.AddCommand(new plotDialog("", "1", "一个平凡的屎壳郎的墓碑", 0));
        plotManager.Instance.AddCommand(new plotEnd());

    }
    public static void plotShow5()
    {



    }
    public static void plotShow6()
    {
        plotManager.Instance.AddCommand(new plotStart());
        plotManager.Instance.AddCommand(new plotDialog("", "1", "迟到了", 0));
        plotManager.Instance.AddCommand(new plotDialog("", "1", "请在10秒内到达公司", 0));
        plotManager.Instance.AddCommand(new plotEnd());

    }
    public static void plotShow7()
    {

        plotManager.Instance.AddCommand(new plotStart());
        plotManager.Instance.AddCommand(new plotDialog("", "1", "开始上班了", 0));
        plotManager.Instance.AddCommand(new plotDialog("", "1", "请遵守时间表", 0));
        plotManager.Instance.AddCommand(new plotEnd());

    }
    public static void plotShow8()
    {

        plotManager.Instance.AddCommand(new plotStart());
        plotManager.Instance.AddCommand(new plotDialog("", "1", "呜呜呜！", 0));
        plotManager.Instance.AddCommand(new plotDialog("", "1", "终于下班了", 0));
        plotManager.Instance.AddCommand(new plotEnd());

    }
    public static void plotShow9()
    {
        plotManager.Instance.AddCommand(new plotStart());
        plotManager.Instance.AddCommand(new plotDialog("", "1", "找到电脑", 0));
        plotManager.Instance.AddCommand(new plotEnd());

    }
    public static void plotShow10()
    {

        plotManager.Instance.AddCommand(new plotStart());
        plotManager.Instance.AddCommand(new plotDialog("", "1", "恭喜你找到了电脑", 0));
        plotManager.Instance.AddCommand(new plotDialog("", "1", "找到校服", 0));
        plotManager.Instance.AddCommand(new plotEnd());

    }
    public static void plotShow11()
    {

        plotManager.Instance.AddCommand(new plotStart());
        plotManager.Instance.AddCommand(new plotDialog("", "1", "恭喜你找到了校服", 0));
        plotManager.Instance.AddCommand(new plotDialog("", "1", "找到画笔", 0));
        plotManager.Instance.AddCommand(new plotEnd());

    }
    public static void plotShow12()
    {

        plotManager.Instance.AddCommand(new plotStart());
        plotManager.Instance.AddCommand(new plotDialog("", "1", "恭喜你找到了画笔", 0));
        plotManager.Instance.AddCommand(new plotDialog("", "1", "找到全家福", 0)); ;
        plotManager.Instance.AddCommand(new plotEnd());

    }
    public static void plotShow13()
    {

        plotManager.Instance.AddCommand(new plotStart());
        plotManager.Instance.AddCommand(new plotDialog("", "1", "恭喜你找到了全家福", 0));
        plotManager.Instance.AddCommand(new plotDialog("", "1", "找到手柄", 0));
        plotManager.Instance.AddCommand(new plotEnd());

    }
    public static void plotShow14()
    {

        plotManager.Instance.AddCommand(new plotStart());
        plotManager.Instance.AddCommand(new plotDialog("", "1", "恭喜你找到了手柄", 0));
        plotManager.Instance.AddCommand(new plotDialog("", "1", "去寻找最后一个物品吧", 0));
        plotManager.Instance.AddCommand(new plotEnd());

    }
    public static void plotShow15()
    {

        plotManager.Instance.AddCommand(new plotStart());
        plotManager.Instance.AddCommand(new plotDialog("", "1", "你为什么狠心抛弃我", 0));
        plotManager.Instance.AddCommand(new plotDialog("", "1", "啊啊啊啊", 0));
        plotManager.Instance.AddCommand(new plotEnd());

    }
    public static void plotShow16()
    {

        plotManager.Instance.AddCommand(new plotStart());
        plotManager.Instance.AddCommand(new plotDialog("", "1", "恭喜你找到了最心爱的玩偶", 0));
        plotManager.Instance.AddCommand(new plotDialog("", "1", "找到了快乐", 0));
        plotManager.Instance.AddCommand(new plotEnd());

    }
}
